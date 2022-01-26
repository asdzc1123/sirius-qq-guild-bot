package networkplugin

import (
	"encoding/json"
	"errors"
	"github.com/google/uuid"
	"github.com/gorilla/websocket"
	"github.com/tencent-connect/botgo/dto"
	"github.com/tencent-connect/botgo/log"
	"io/ioutil"
	"net/http"
	"sirius-core/core/global"
	"sync"
)

var (
	upgrader = websocket.Upgrader{
		CheckOrigin: func(r *http.Request) bool {
			return true
		},
	}
	boolResult = map[bool][]byte{
		false: []byte("false"),
		true:  []byte("true"),
	}
	WSServer *server
	mutex    sync.Mutex
)

type server struct {
	clients        map[*client]bool
	registerChan   chan *client
	unregisterChan chan *client
}

type client struct {
	name         string
	token        string
	conn         *websocket.Conn
	sendJsonChan chan interface{}
}

func (server *server) ClientManager() {
	for {
		select {
		case client := <-server.registerChan:
			mutex.Lock()
			server.clients[client] = true
			err := client.conn.WriteMessage(websocket.TextMessage, []byte(client.token))
			if err != nil {
				log.Error("向网络插件发送token失败")
				server.unregisterChan <- client
			} else {
				log.Infof("网络插件[%s]连接到WebSocket", client.name)
			}
			mutex.Unlock()
		case client := <-server.unregisterChan:
			mutex.Lock()
			log.Infof("网络插件[%s]断开连接", client.name)
			if _, ok := server.clients[client]; ok {
				close(client.sendJsonChan)
				delete(server.clients, client)
				_ = client.conn.Close()
			}
			mutex.Unlock()
		}
	}
}

func (server *server) SendJsonMessage(jsonMessage interface{}) {
	for client := range server.clients {
		client.sendJsonChan <- jsonMessage
	}
}

func (client *client) handler() {

	go func() {
		for {
			_, _, err := client.conn.ReadMessage()
			if err != nil {
				WSServer.unregisterChan <- client
				break
			}
		}
	}()
	for jsonMessage := range client.sendJsonChan {
		err := client.conn.WriteJSON(jsonMessage)
		if err != nil {
			break
		}
	}
}

func (server *server) checkToken(name, token string) bool {
	log.Debugf("checkToken name:%s ,token:%s", name, token)
	for c := range server.clients {
		if name == c.name && token == c.token {
			return true
		}
	}
	return false
}

func (server *server) nameIsExist(name string) bool {
	for c := range server.clients {
		if name == c.name {
			return true
		}
	}
	return false
}

func wsPluginEventsHandler(w http.ResponseWriter, r *http.Request) {

	if !r.URL.Query().Has("name") {
		httpWrite(w, http.StatusBadRequest, "name为空")
		return
	}
	name := r.URL.Query().Get("name")
	if WSServer.nameIsExist(name) {
		httpWrite(w, http.StatusForbidden, "name已经存在")
		return
	}

	conn, err := upgrader.Upgrade(w, r, nil)
	if err != nil {
		return
	}

	client := client{
		name:         name,
		token:        uuid.New().String(),
		conn:         conn,
		sendJsonChan: make(chan interface{}),
	}
	WSServer.registerChan <- &client
	go client.handler()
}

func checkTokenByRequest(r *http.Request) bool {
	return WSServer.checkToken(r.URL.Query().Get("name"), r.Header.Get("token"))
}

func httpWrite(w http.ResponseWriter, statusCode int, body string) {
	w.WriteHeader(statusCode)
	_, _ = w.Write([]byte(body))
}

func httpDecodeJson(r *http.Request, jsonStruct interface{}) error {
	bytes, err := ioutil.ReadAll(r.Body)
	if err != nil {
		return errors.New("读取字节流失败")
	}
	return json.Unmarshal(bytes, jsonStruct)
}

func httpWriteJson(w http.ResponseWriter, jsonStruct interface{}) {
	bytes, err := json.Marshal(jsonStruct)
	if err != nil {
		return
	}
	_, _ = w.Write(bytes)
}

func httpWriteBool(w http.ResponseWriter, result bool) {
	_, _ = w.Write(boolResult[result])
}

//参数 "channel_id", "message_id"
func httpMessageHandler(w http.ResponseWriter, r *http.Request) {
	type Params struct {
		ChannelID string `json:"channel_id"`
		MessageID string `json:"message_id"`
	}
	if !checkTokenByRequest(r) {
		httpWrite(w, http.StatusUnauthorized, "验证失败")
		return
	}

	var params Params
	err := httpDecodeJson(r, &params)
	if err != nil {
		httpWrite(w, http.StatusForbidden, err.Error())
		return
	}

	if err != nil {
		httpWrite(w, http.StatusBadRequest, err.Error())
		return
	}

	result, err := global.Api.Message(global.Ctx, params.ChannelID, params.MessageID)
	if err != nil {
		//500
		httpWrite(w, http.StatusInternalServerError, err.Error())
		return
	}

	httpWriteJson(w, result)
}

//参数 "channel_id", "pager_json"
func httpMessagesHandler(w http.ResponseWriter, r *http.Request) {
	type Params struct {
		ChannelID string             `json:"channel_id"`
		Pager     *dto.MessagesPager `json:"pager_json"`
	}
	if !checkTokenByRequest(r) {
		httpWrite(w, http.StatusUnauthorized, "验证失败")
		return
	}

	var params Params
	err := httpDecodeJson(r, &params)
	if err != nil {
		httpWrite(w, http.StatusForbidden, err.Error())
		return
	}

	if err != nil {
		httpWrite(w, http.StatusBadRequest, err.Error())
		return
	}

	result, err := global.Api.Messages(global.Ctx, params.ChannelID, params.Pager)
	if err != nil {
		//500
		httpWrite(w, http.StatusInternalServerError, err.Error())
		return
	}

	httpWriteJson(w, result)
}

//参数 "channel_id", "message_json"
func httpPostMessageHandler(w http.ResponseWriter, r *http.Request) {
	type Params struct {
		ChannelID string               `json:"channel_id"`
		Message   *dto.MessageToCreate `json:"message_json"`
	}
	if !checkTokenByRequest(r) {
		httpWrite(w, http.StatusUnauthorized, "验证失败")
		return
	}

	var params Params
	err := httpDecodeJson(r, &params)
	if err != nil {
		httpWrite(w, http.StatusForbidden, err.Error())
		return
	}

	if err != nil {
		httpWrite(w, http.StatusBadRequest, err.Error())
		return
	}

	result, err := global.Api.PostMessage(global.Ctx, params.ChannelID, params.Message)
	if err != nil {
		//500
		httpWrite(w, http.StatusInternalServerError, err.Error())
		return
	}

	httpWriteJson(w, result)
}

//参数 "channel_id", "message_id"
func httpRetractMessageHandler(w http.ResponseWriter, r *http.Request) {
	type Params struct {
		ChannelID string `json:"channel_id"`
		MessageID string `json:"message_id"`
	}
	if !checkTokenByRequest(r) {
		httpWrite(w, http.StatusUnauthorized, "验证失败")
		return
	}

	var params Params
	err := httpDecodeJson(r, &params)
	if err != nil {
		httpWrite(w, http.StatusForbidden, err.Error())
		return
	}

	if err != nil {
		httpWrite(w, http.StatusBadRequest, err.Error())
		return
	}

	err = global.Api.RetractMessage(global.Ctx, params.ChannelID, params.MessageID)
	if err != nil {
		//500
		httpWrite(w, http.StatusInternalServerError, err.Error())
		return
	}

	httpWriteBool(w, err == nil)
}

//参数 "guild_id"
func httpGuildHandler(w http.ResponseWriter, r *http.Request) {
	type Params struct {
		GuildID string `json:"guild_id"`
	}
	if !checkTokenByRequest(r) {
		httpWrite(w, http.StatusUnauthorized, "验证失败")
		return
	}

	var params Params
	err := httpDecodeJson(r, &params)
	if err != nil {
		httpWrite(w, http.StatusForbidden, err.Error())
		return
	}

	if err != nil {
		httpWrite(w, http.StatusBadRequest, err.Error())
		return
	}

	result, err := global.Api.Guild(global.Ctx, params.GuildID)
	if err != nil {
		//500
		httpWrite(w, http.StatusInternalServerError, err.Error())
		return
	}

	httpWriteJson(w, result)
}

//参数 "guild_id", "user_id"
func httpGuildMemberHandler(w http.ResponseWriter, r *http.Request) {
	type Params struct {
		GuildID string `json:"guild_id"`
		UserID  string `json:"user_id"`
	}
	if !checkTokenByRequest(r) {
		httpWrite(w, http.StatusUnauthorized, "验证失败")
		return
	}

	var params Params
	err := httpDecodeJson(r, &params)
	if err != nil {
		httpWrite(w, http.StatusForbidden, err.Error())
		return
	}

	if err != nil {
		httpWrite(w, http.StatusBadRequest, err.Error())
		return
	}

	result, err := global.Api.GuildMember(global.Ctx, params.GuildID, params.UserID)
	if err != nil {
		//500
		httpWrite(w, http.StatusInternalServerError, err.Error())
		return
	}

	httpWriteJson(w, result)
}

//参数 "guild_id", "pager_json"
func httpGuildMembersHandler(w http.ResponseWriter, r *http.Request) {
	type Params struct {
		GuildID string                 `json:"guild_id"`
		Pager   *dto.GuildMembersPager `json:"pager_json"`
	}
	if !checkTokenByRequest(r) {
		httpWrite(w, http.StatusUnauthorized, "验证失败")
		return
	}

	var params Params
	err := httpDecodeJson(r, &params)
	if err != nil {
		httpWrite(w, http.StatusForbidden, err.Error())
		return
	}

	if err != nil {
		httpWrite(w, http.StatusBadRequest, err.Error())
		return
	}

	result, err := global.Api.GuildMembers(global.Ctx, params.GuildID, params.Pager)
	if err != nil {
		//500
		httpWrite(w, http.StatusInternalServerError, err.Error())
		return
	}

	httpWriteJson(w, result)
}

//参数 "guild_id", "user_id"
func httpDeleteGuildMemberHandler(w http.ResponseWriter, r *http.Request) {
	type Params struct {
		GuildID string `json:"guild_id"`
		UserID  string `json:"user_id"`
	}
	if !checkTokenByRequest(r) {
		httpWrite(w, http.StatusUnauthorized, "验证失败")
		return
	}

	var params Params
	err := httpDecodeJson(r, &params)
	if err != nil {
		httpWrite(w, http.StatusForbidden, err.Error())
		return
	}

	if err != nil {
		httpWrite(w, http.StatusBadRequest, err.Error())
		return
	}

	err = global.Api.DeleteGuildMember(global.Ctx, params.GuildID, params.UserID)
	if err != nil {
		//500
		httpWrite(w, http.StatusInternalServerError, err.Error())
		return
	}

	httpWriteBool(w, err == nil)
}

//参数 "guild_id", "mute_json"
func httpGuildMuteHandler(w http.ResponseWriter, r *http.Request) {
	type Params struct {
		GuildID string               `json:"guild_id"`
		Mute    *dto.UpdateGuildMute `json:"mute_json"`
	}
	if !checkTokenByRequest(r) {
		httpWrite(w, http.StatusUnauthorized, "验证失败")
		return
	}

	var params Params
	err := httpDecodeJson(r, &params)
	if err != nil {
		httpWrite(w, http.StatusForbidden, err.Error())
		return
	}

	if err != nil {
		httpWrite(w, http.StatusBadRequest, err.Error())
		return
	}

	err = global.Api.GuildMute(global.Ctx, params.GuildID, params.Mute)
	if err != nil {
		//500
		httpWrite(w, http.StatusInternalServerError, err.Error())
		return
	}

	httpWriteBool(w, err == nil)
}

//参数 "channel_id"
func httpChannelHandler(w http.ResponseWriter, r *http.Request) {
	type Params struct {
		ChannelID string `json:"channel_id"`
	}
	if !checkTokenByRequest(r) {
		httpWrite(w, http.StatusUnauthorized, "验证失败")
		return
	}

	var params Params
	err := httpDecodeJson(r, &params)
	if err != nil {
		httpWrite(w, http.StatusForbidden, err.Error())
		return
	}

	if err != nil {
		httpWrite(w, http.StatusBadRequest, err.Error())
		return
	}

	result, err := global.Api.Channel(global.Ctx, params.ChannelID)
	if err != nil {
		//500
		httpWrite(w, http.StatusInternalServerError, err.Error())
		return
	}

	httpWriteJson(w, result)
}

//参数 "guild_id"
func httpChannelsHandler(w http.ResponseWriter, r *http.Request) {
	type Params struct {
		GuildID string `json:"guild_id"`
	}
	if !checkTokenByRequest(r) {
		httpWrite(w, http.StatusUnauthorized, "验证失败")
		return
	}

	var params Params
	err := httpDecodeJson(r, &params)
	if err != nil {
		httpWrite(w, http.StatusForbidden, err.Error())
		return
	}

	if err != nil {
		httpWrite(w, http.StatusBadRequest, err.Error())
		return
	}

	result, err := global.Api.Channels(global.Ctx, params.GuildID)
	if err != nil {
		//500
		httpWrite(w, http.StatusInternalServerError, err.Error())
		return
	}

	httpWriteJson(w, result)
}

//参数 "guild_id", "channel_value_object_json"
func httpPostChannelHandler(w http.ResponseWriter, r *http.Request) {
	type Params struct {
		GuildID            string                  `json:"guild_id"`
		ChannelValueObject *dto.ChannelValueObject `json:"channel_value_object_json"`
	}
	if !checkTokenByRequest(r) {
		httpWrite(w, http.StatusUnauthorized, "验证失败")
		return
	}

	var params Params
	err := httpDecodeJson(r, &params)
	if err != nil {
		httpWrite(w, http.StatusForbidden, err.Error())
		return
	}

	if err != nil {
		httpWrite(w, http.StatusBadRequest, err.Error())
		return
	}

	result, err := global.Api.PostChannel(global.Ctx, params.GuildID, params.ChannelValueObject)
	if err != nil {
		//500
		httpWrite(w, http.StatusInternalServerError, err.Error())
		return
	}

	httpWriteJson(w, result)
}

//参数 "channel_id", "channel_value_object_json"
func httpPatchChannelHandler(w http.ResponseWriter, r *http.Request) {
	type Params struct {
		GuildID            string                  `json:"guild_id"`
		ChannelValueObject *dto.ChannelValueObject `json:"channel_value_object_json"`
	}
	if !checkTokenByRequest(r) {
		httpWrite(w, http.StatusUnauthorized, "验证失败")
		return
	}

	var params Params
	err := httpDecodeJson(r, &params)
	if err != nil {
		httpWrite(w, http.StatusForbidden, err.Error())
		return
	}

	if err != nil {
		httpWrite(w, http.StatusBadRequest, err.Error())
		return
	}

	result, err := global.Api.PatchChannel(global.Ctx, params.GuildID, params.ChannelValueObject)
	if err != nil {
		//500
		httpWrite(w, http.StatusInternalServerError, err.Error())
		return
	}

	httpWriteJson(w, result)
}

//参数 "channel_id"
func httpDeleteChannelHandler(w http.ResponseWriter, r *http.Request) {
	type Params struct {
		ChannelID string `json:"channel_id"`
	}
	if !checkTokenByRequest(r) {
		httpWrite(w, http.StatusUnauthorized, "验证失败")
		return
	}

	var params Params
	err := httpDecodeJson(r, &params)
	if err != nil {
		httpWrite(w, http.StatusForbidden, err.Error())
		return
	}

	if err != nil {
		httpWrite(w, http.StatusBadRequest, err.Error())
		return
	}

	err = global.Api.DeleteChannel(global.Ctx, params.ChannelID)
	if err != nil {
		//500
		httpWrite(w, http.StatusInternalServerError, err.Error())
		return
	}

	httpWriteBool(w, err == nil)
}

//无参数
func httpMeHandler(w http.ResponseWriter, r *http.Request) {

	if !checkTokenByRequest(r) {
		httpWrite(w, http.StatusUnauthorized, "验证失败")
		return
	}

	result, err := global.Api.Me(global.Ctx)
	if err != nil {
		//500
		httpWrite(w, http.StatusInternalServerError, err.Error())
		return
	}

	httpWriteJson(w, result)
}

//参数 "pager_json"
func httpMeGuildsHandler(w http.ResponseWriter, r *http.Request) {
	type Params struct {
		Pager *dto.GuildPager `json:"pager_json"`
	}
	if !checkTokenByRequest(r) {
		httpWrite(w, http.StatusUnauthorized, "验证失败")
		return
	}

	var params Params
	err := httpDecodeJson(r, &params)
	if err != nil {
		httpWrite(w, http.StatusForbidden, err.Error())
		return
	}

	if err != nil {
		httpWrite(w, http.StatusBadRequest, err.Error())
		return
	}

	result, err := global.Api.MeGuilds(global.Ctx, params.Pager)
	if err != nil {
		//500
		httpWrite(w, http.StatusInternalServerError, err.Error())
		return
	}

	httpWriteJson(w, result)
}

//参数 "guild_id", "role_id", "user_id", "value_json"
func httpMemberAddRoleHandler(w http.ResponseWriter, r *http.Request) {
	type Params struct {
		GuildID string                 `json:"guild_id"`
		RoleID  string                 `json:"role_id"`
		UserID  string                 `json:"user_id"`
		Value   *dto.MemberAddRoleBody `json:"value_json"`
	}
	if !checkTokenByRequest(r) {
		httpWrite(w, http.StatusUnauthorized, "验证失败")
		return
	}

	var params Params
	err := httpDecodeJson(r, &params)
	if err != nil {
		httpWrite(w, http.StatusForbidden, err.Error())
		return
	}

	if err != nil {
		httpWrite(w, http.StatusBadRequest, err.Error())
		return
	}

	err = global.Api.MemberAddRole(global.Ctx, params.GuildID, dto.RoleID(params.RoleID), params.UserID, params.Value)
	if err != nil {
		//500
		httpWrite(w, http.StatusInternalServerError, err.Error())
		return
	}

	httpWriteBool(w, err == nil)
}

//参数 "guild_id", "role_id", "user_id", "value_json"
func httpMemberDeleteRoleHandler(w http.ResponseWriter, r *http.Request) {
	type Params struct {
		GuildID string                 `json:"guild_id"`
		RoleID  string                 `json:"role_id"`
		UserID  string                 `json:"user_id"`
		Value   *dto.MemberAddRoleBody `json:"value_json"`
	}
	if !checkTokenByRequest(r) {
		httpWrite(w, http.StatusUnauthorized, "验证失败")
		return
	}

	var params Params
	err := httpDecodeJson(r, &params)
	if err != nil {
		httpWrite(w, http.StatusForbidden, err.Error())
		return
	}

	if err != nil {
		httpWrite(w, http.StatusBadRequest, err.Error())
		return
	}

	err = global.Api.MemberDeleteRole(global.Ctx, params.GuildID, dto.RoleID(params.RoleID), params.UserID, params.Value)
	if err != nil {
		//500
		httpWrite(w, http.StatusInternalServerError, err.Error())
		return
	}

	httpWriteBool(w, err == nil)
}

//参数 "guild_id", "user_id", "mute_json"
func httpMemberMuteHandler(w http.ResponseWriter, r *http.Request) {
	type Params struct {
		GuildID string               `json:"guild_id"`
		UserID  string               `json:"user_id"`
		Mute    *dto.UpdateGuildMute `json:"mute_json"`
	}
	if !checkTokenByRequest(r) {
		httpWrite(w, http.StatusUnauthorized, "验证失败")
		return
	}

	var params Params
	err := httpDecodeJson(r, &params)
	if err != nil {
		httpWrite(w, http.StatusForbidden, err.Error())
		return
	}

	if err != nil {
		httpWrite(w, http.StatusBadRequest, err.Error())
		return
	}

	err = global.Api.MemberMute(global.Ctx, params.GuildID, params.UserID, params.Mute)
	if err != nil {
		//500
		httpWrite(w, http.StatusInternalServerError, err.Error())
		return
	}

	httpWriteBool(w, err == nil)
}

func NewWSServer() *server {
	return &server{
		clients:        make(map[*client]bool),
		registerChan:   make(chan *client),
		unregisterChan: make(chan *client),
	}
}

func ListenAndServe(addr string) error {
	mux := http.NewServeMux()
	mux.HandleFunc("/plugin/events", wsPluginEventsHandler)
	mux.HandleFunc("/openapi/message", httpMessageHandler)
	mux.HandleFunc("/openapi/messages", httpMessagesHandler)
	mux.HandleFunc("/openapi/post-message", httpPostMessageHandler)
	mux.HandleFunc("/openapi/retract-message", httpRetractMessageHandler)
	mux.HandleFunc("/openapi/guild", httpGuildHandler)
	mux.HandleFunc("/openapi/guild-member", httpGuildMemberHandler)
	mux.HandleFunc("/openapi/guild-members", httpGuildMembersHandler)
	mux.HandleFunc("/openapi/delete-guild-member", httpDeleteGuildMemberHandler)
	mux.HandleFunc("/openapi/guild-mute", httpGuildMuteHandler)
	mux.HandleFunc("/openapi/channel", httpChannelHandler)
	mux.HandleFunc("/openapi/channels", httpChannelsHandler)
	mux.HandleFunc("/openapi/post-channel", httpPostChannelHandler)
	mux.HandleFunc("/openapi/patch-channel", httpPatchChannelHandler)
	mux.HandleFunc("/openapi/delete-channel", httpDeleteChannelHandler)
	mux.HandleFunc("/openapi/me", httpMeHandler)
	mux.HandleFunc("/openapi/me-guilds", httpMeGuildsHandler)
	mux.HandleFunc("/openapi/member-add-role", httpMemberAddRoleHandler)
	mux.HandleFunc("/openapi/member-delete-role", httpMemberDeleteRoleHandler)
	mux.HandleFunc("/openapi/member-mute", httpMemberMuteHandler)
	go WSServer.ClientManager()
	return http.ListenAndServe(addr, mux)
}
