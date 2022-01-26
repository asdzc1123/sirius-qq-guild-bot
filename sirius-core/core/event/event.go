package event

import (
	"encoding/json"
	"github.com/tencent-connect/botgo/dto"
	"sirius-core/core/native"
	"sirius-core/core/networkplugin"
)

type wsEvent struct {
	Name string      `json:"name"`
	Data interface{} `json:"data"`
}

func GuildEventHandler(event *dto.WSPayload, data *dto.WSGuildData) error {

	eventJsonBytes, err := json.Marshal(event)
	dataJsonBytes, err := json.Marshal(data)
	if err != nil {
		return err
	}

	_, _, _ = native.Call(
		GlobalSettings.Guild.Address,
		native.BytesStringPtr(eventJsonBytes),
		native.BytesStringPtr(dataJsonBytes),
	)

	if networkplugin.WSServer != nil {
		networkplugin.WSServer.SendJsonMessage(wsEvent{
			Name: "GuildEventHandler",
			Data: data,
		})
	}
	return nil
}

func GuildMemberEventHandler(event *dto.WSPayload, data *dto.WSGuildMemberData) error {

	eventJsonBytes, err := json.Marshal(event)
	dataJsonBytes, err := json.Marshal(data)
	if err != nil {
		return err
	}

	_, _, _ = native.Call(
		GlobalSettings.GuildMember.Address,
		native.BytesStringPtr(eventJsonBytes),
		native.BytesStringPtr(dataJsonBytes),
	)

	if networkplugin.WSServer != nil {
		networkplugin.WSServer.SendJsonMessage(wsEvent{
			Name: "GuildMemberEventHandler",
			Data: data,
		})
	}
	return nil
}

func ChannelEventHandler(event *dto.WSPayload, data *dto.WSChannelData) error {

	eventJsonBytes, err := json.Marshal(event)
	dataJsonBytes, err := json.Marshal(data)
	if err != nil {
		return err
	}

	_, _, _ = native.Call(
		GlobalSettings.Channel.Address,
		native.BytesStringPtr(eventJsonBytes),
		native.BytesStringPtr(dataJsonBytes),
	)

	if networkplugin.WSServer != nil {
		networkplugin.WSServer.SendJsonMessage(wsEvent{
			Name: "ChannelEventHandler",
			Data: data,
		})
	}
	return nil
}

func MessageEventHandler(event *dto.WSPayload, data *dto.WSMessageData) error {

	eventJsonBytes, err := json.Marshal(event)
	dataJsonBytes, err := json.Marshal(data)
	if err != nil {
		return err
	}

	_, _, _ = native.Call(
		GlobalSettings.Message.Address,
		native.BytesStringPtr(eventJsonBytes),
		native.BytesStringPtr(dataJsonBytes),
	)

	if networkplugin.WSServer != nil {
		networkplugin.WSServer.SendJsonMessage(wsEvent{
			Name: "MessageEventHandler",
			Data: data,
		})
	}
	return nil
}

func MessageReactionEventHandler(event *dto.WSPayload, data *dto.WSMessageReactionData) error {

	eventJsonBytes, err := json.Marshal(event)
	dataJsonBytes, err := json.Marshal(data)
	if err != nil {
		return err
	}

	_, _, _ = native.Call(
		GlobalSettings.MessageReaction.Address,
		native.BytesStringPtr(eventJsonBytes),
		native.BytesStringPtr(dataJsonBytes),
	)

	if networkplugin.WSServer != nil {
		networkplugin.WSServer.SendJsonMessage(wsEvent{
			Name: "MessageReactionEventHandler",
			Data: data,
		})
	}
	return nil
}

func ATMessageEventHandler(event *dto.WSPayload, data *dto.WSATMessageData) error {

	eventJsonBytes, err := json.Marshal(event)
	dataJsonBytes, err := json.Marshal(data)
	if err != nil {
		return err
	}

	_, _, _ = native.Call(
		GlobalSettings.ATMessage.Address,
		native.BytesStringPtr(eventJsonBytes),
		native.BytesStringPtr(dataJsonBytes),
	)

	if networkplugin.WSServer != nil {
		networkplugin.WSServer.SendJsonMessage(wsEvent{
			Name: "ATMessageEventHandler",
			Data: data,
		})
	}

	return nil
}

func DirectMessageEventHandler(event *dto.WSPayload, data *dto.WSDirectMessageData) error {

	eventJsonBytes, err := json.Marshal(event)
	dataJsonBytes, err := json.Marshal(data)
	if err != nil {
		return err
	}

	_, _, _ = native.Call(
		GlobalSettings.DirectMessage.Address,
		native.BytesStringPtr(eventJsonBytes),
		native.BytesStringPtr(dataJsonBytes),
	)

	if networkplugin.WSServer != nil {
		networkplugin.WSServer.SendJsonMessage(wsEvent{
			Name: "DirectMessageEventHandler",
			Data: data,
		})
	}
	return nil
}

func AudioMessageEventHandler(event *dto.WSPayload, data *dto.WSAudioData) error {

	eventJsonBytes, err := json.Marshal(event)
	dataJsonBytes, err := json.Marshal(data)
	if err != nil {
		return err
	}

	_, _, _ = native.Call(
		GlobalSettings.Audio.Address,
		native.BytesStringPtr(eventJsonBytes),
		native.BytesStringPtr(dataJsonBytes),
	)

	if networkplugin.WSServer != nil {
		networkplugin.WSServer.SendJsonMessage(wsEvent{
			Name: "AudioMessageEventHandler",
			Data: data,
		})
	}
	return nil
}
