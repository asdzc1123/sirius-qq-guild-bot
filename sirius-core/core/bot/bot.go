package bot

import (
	"encoding/json"
	"github.com/tencent-connect/botgo"
	"github.com/tencent-connect/botgo/dto"
	"github.com/tencent-connect/botgo/log"
	"github.com/tencent-connect/botgo/token"
	"github.com/tencent-connect/botgo/websocket"
	"sirius-core/core/event"
	"sirius-core/core/global"
	"sirius-core/core/native"
	"sirius-core/core/networkplugin"
	"strconv"
	"time"
)

var readyFunc uintptr

func EnableGuildEventHandler(funcAddress uintptr) {
	event.GlobalSettings.Guild.Enable = true
	event.GlobalSettings.Guild.Address = funcAddress
	event.GlobalSettings.Guild.Handler = websocket.GuildEventHandler(event.GuildEventHandler)
	log.Info("频道事件启用")
}

func EnableGuildMemberEventHandler(funcAddress uintptr) {
	event.GlobalSettings.GuildMember.Enable = true
	event.GlobalSettings.GuildMember.Address = funcAddress
	event.GlobalSettings.GuildMember.Handler = websocket.GuildMemberEventHandler(event.GuildMemberEventHandler)
	log.Info("频道成员事件启用")
}

func EnableChannelEventHandler(funcAddress uintptr) {
	event.GlobalSettings.Channel.Enable = true
	event.GlobalSettings.Channel.Address = funcAddress
	event.GlobalSettings.Channel.Handler = websocket.ChannelEventHandler(event.ChannelEventHandler)
	log.Info("子频道事件启用")
}

func EnableMessageEventHandler(funcAddress uintptr) {
	event.GlobalSettings.Message.Enable = true
	event.GlobalSettings.Message.Address = funcAddress
	event.GlobalSettings.Message.Handler = websocket.MessageEventHandler(event.MessageEventHandler)
	log.Info("消息事件启用")
}

func EnableMessageReactionEventHandler(funcAddress uintptr) {
	event.GlobalSettings.MessageReaction.Enable = true
	event.GlobalSettings.MessageReaction.Address = funcAddress
	event.GlobalSettings.MessageReaction.Handler = websocket.MessageReactionEventHandler(event.MessageReactionEventHandler)
	log.Info("表情表态事件启用")
}

func EnableATMessageEventHandler(funcAddress uintptr) {
	event.GlobalSettings.ATMessage.Enable = true
	event.GlobalSettings.ATMessage.Address = funcAddress
	event.GlobalSettings.ATMessage.Handler = websocket.ATMessageEventHandler(event.ATMessageEventHandler)
	log.Info("@机器人消息事件启用")
}

func EnableDirectMessageEventHandler(funcAddress uintptr) {
	event.GlobalSettings.DirectMessage.Enable = true
	event.GlobalSettings.DirectMessage.Address = funcAddress
	event.GlobalSettings.DirectMessage.Handler = websocket.DirectMessageEventHandler(event.DirectMessageEventHandler)
	log.Info("私聊事件启用")
}

func EnableAudioEventHandler(funcAddress uintptr) {
	event.GlobalSettings.Audio.Enable = true
	event.GlobalSettings.Audio.Address = funcAddress
	event.GlobalSettings.Audio.Handler = websocket.AudioEventHandler(event.AudioMessageEventHandler)
	log.Info("音频事件启用")
}

var started = false

func Login(readyFuncAddress uintptr, appID uint64, accessToken string) {
	readyFunc = readyFuncAddress
	global.BotToken = token.BotToken(appID, accessToken)

	global.Api = botgo.NewOpenAPI(global.BotToken).WithTimeout(3 * time.Second)

	if started {
		log.Warn("已经登录过了")
		return
	}
	defer func() {
		if r := recover(); r != nil {
			log.Errorf("恐慌,发生错误:%+v", r)
			return
		}
	}()

	ws, err := global.Api.WS(global.Ctx, nil, "")

	if err != nil {
		log.Errorf("WebSocket无法监听,%+v, err:%v\n", ws, err)
		return
	}

	handlers := make([]interface{}, 0)

	if event.GlobalSettings.Guild.Enable {
		handlers = append(handlers, event.GlobalSettings.Guild.Handler)
	}

	if event.GlobalSettings.GuildMember.Enable {
		handlers = append(handlers, event.GlobalSettings.GuildMember.Handler)
	}

	if event.GlobalSettings.Channel.Enable {
		handlers = append(handlers, event.GlobalSettings.Channel.Handler)
	}

	if event.GlobalSettings.Message.Enable {
		handlers = append(handlers, event.GlobalSettings.Message.Handler)
	}

	if event.GlobalSettings.MessageReaction.Enable {
		handlers = append(handlers, event.GlobalSettings.MessageReaction.Handler)
	}

	if event.GlobalSettings.ATMessage.Enable {
		handlers = append(handlers, event.GlobalSettings.ATMessage.Handler)
	}

	if event.GlobalSettings.DirectMessage.Enable {
		handlers = append(handlers, event.GlobalSettings.DirectMessage.Handler)
	}

	if event.GlobalSettings.Audio.Enable {
		handlers = append(handlers, event.GlobalSettings.Audio.Handler)
	}

	handlers = append(handlers, websocket.ReadyHandler(readyEventHandler))

	intent := websocket.RegisterHandlers(handlers...)
	started = true
	go func() {
		defer func() {
			if r := recover(); r != nil {
				log.Errorf("恐慌,Bot无法登录:%+v", r)
				started = false
				return
			}
		}()
		err = botgo.NewSessionManager().Start(ws, global.BotToken, &intent)
		if err != nil {
			log.Errorf("启动失败%+v, err:%v\n", ws, err)
		}
		started = false
	}()

}

func StartNetworkPluginServer(bindPort uint16) {
	if networkplugin.WSServer != nil {
		log.Warn("已经启动过网络插件服务了")
		return
	}

	networkplugin.WSServer = networkplugin.NewWSServer()
	go func() {
		var addr = "localhost:" + strconv.Itoa(int(bindPort))
		log.Infof("启动网络插件服务:%s", addr)
		err := networkplugin.ListenAndServe(addr)
		if err != nil {
			networkplugin.WSServer = nil
			log.Errorf("启动网络插件服务失败:%+v", err)
		}
	}()

}

func readyEventHandler(event *dto.WSPayload, data *dto.WSReadyData) {

	eventBytes, _ := json.Marshal(event)
	log.Debug(string(eventBytes))
	dataBytes, _ := json.Marshal(data)
	_, _, _ = native.Call(readyFunc,
		native.BytesStringPtr(eventBytes),
		native.BytesStringPtr(dataBytes),
	)
}
