package main

import "C"
import (
	"fmt"
	"sirius-core/core/api"
	"sirius-core/core/bot"
	"sirius-core/core/native"
)

//export Login
func Login(readyFuncAddress uintptr, appID uint64, accessToken *C.char) {
	bot.Login(readyFuncAddress, appID, native.DeepCopyString(C.GoString(accessToken)))
}

//export EnableGuildEventHandler
func EnableGuildEventHandler(funcAddress uintptr) {
	bot.EnableGuildEventHandler(funcAddress)
}

//export EnableGuildMemberEventHandler
func EnableGuildMemberEventHandler(funcAddress uintptr) {
	bot.EnableGuildMemberEventHandler(funcAddress)
}

//export EnableChannelEventHandler
func EnableChannelEventHandler(funcAddress uintptr) {
	bot.EnableChannelEventHandler(funcAddress)
}

//export EnableMessageEventHandler
func EnableMessageEventHandler(funcAddress uintptr) {
	bot.EnableMessageEventHandler(funcAddress)
}

//export EnableMessageReactionEventHandler
func EnableMessageReactionEventHandler(funcAddress uintptr) {
	bot.EnableMessageReactionEventHandler(funcAddress)
}

//export EnableATMessageEventHandler
func EnableATMessageEventHandler(funcAddress uintptr) {
	bot.EnableATMessageEventHandler(funcAddress)
}

//export EnableDirectMessageEventHandler
func EnableDirectMessageEventHandler(funcAddress uintptr) {
	bot.EnableDirectMessageEventHandler(funcAddress)
}

//export EnableAudioEventHandler
func EnableAudioEventHandler(funcAddress uintptr) {
	bot.EnableAudioEventHandler(funcAddress)
}

//export StartNetworkPluginServer
func StartNetworkPluginServer(bindPort uint16) {
	bot.StartNetworkPluginServer(bindPort)
}

//export SetGoLogOutputFunc
func SetGoLogOutputFunc(funcAddress uintptr) {
	bot.SetGoLogOutputFunc(funcAddress)
}

//export SetOpenApiLogOutputFunc
func SetOpenApiLogOutputFunc(funcAddress uintptr) {
	api.SetOpenApiLogOutputFunc(funcAddress)
}

//export OpenApiMessage
func OpenApiMessage(channelID, messageID *C.char) uintptr {
	result, err := api.Message(
		native.DeepCopyString(C.GoString(channelID)),
		native.DeepCopyString(C.GoString(messageID)),
	)
	if err != nil {
		return 0
	}
	return native.BytesStringPtr(result)
}

//export OpenApiMessages
func OpenApiMessages(channelID, pagerJson *C.char) uintptr {
	result, err := api.Messages(
		native.DeepCopyString(C.GoString(channelID)),
		native.DeepCopyString(C.GoString(pagerJson)),
	)
	if err != nil {
		return 0
	}
	return native.BytesStringPtr(result)
}

//export OpenApiPostMessage
func OpenApiPostMessage(channelID, messageJson *C.char) uintptr {
	result, err := api.PostMessage(
		native.DeepCopyString(C.GoString(channelID)),
		native.DeepCopyString(C.GoString(messageJson)),
	)
	if err != nil {
		return 0
	}
	return native.BytesStringPtr(result)
}

//export OpenApiRetractMessage
func OpenApiRetractMessage(channelID, messageID *C.char) int8 {
	success, err := api.RetractMessage(
		native.DeepCopyString(C.GoString(channelID)),
		native.DeepCopyString(C.GoString(messageID)),
	)
	if err != nil {
		return -1
	} else if success {
		return 1
	} else {
		return 0
	}
}

//export OpenApiGuild
func OpenApiGuild(guildID *C.char) uintptr {
	result, err := api.Guild(
		native.DeepCopyString(C.GoString(guildID)),
	)
	if err != nil {
		return 0
	}
	return native.BytesStringPtr(result)
}

//export OpenApiGuildMember
func OpenApiGuildMember(guildID, userID *C.char) uintptr {
	result, err := api.GuildMember(
		native.DeepCopyString(C.GoString(guildID)),
		native.DeepCopyString(C.GoString(userID)),
	)

	if err != nil {
		return 0
	}
	return native.BytesStringPtr(result)
}

//export OpenApiGuildMembers
func OpenApiGuildMembers(guildID, pagerJson *C.char) uintptr {
	result, err := api.GuildMembers(
		native.DeepCopyString(C.GoString(guildID)),
		native.DeepCopyString(C.GoString(pagerJson)),
	)

	if err != nil {
		return 0
	}
	return native.BytesStringPtr(result)
}

//export OpenApiDeleteGuildMember
func OpenApiDeleteGuildMember(guildID, userID *C.char) int8 {
	success, err := api.DeleteGuildMember(
		native.DeepCopyString(C.GoString(guildID)),
		native.DeepCopyString(C.GoString(userID)),
	)

	if err != nil {
		return -1
	} else if success {
		return 1
	} else {
		return 0
	}
}

//export OpenApiGuildMute
func OpenApiGuildMute(guildID, muteJson *C.char) int8 {
	success, err := api.GuildMute(
		native.DeepCopyString(C.GoString(guildID)),
		native.DeepCopyString(C.GoString(muteJson)),
	)

	if err != nil {
		return -1
	} else if success {
		return 1
	} else {
		return 0
	}
}

//export OpenApiChannel
func OpenApiChannel(channelID *C.char) uintptr {
	result, err := api.Channel(
		native.DeepCopyString(C.GoString(channelID)),
	)

	if err != nil {
		return 0
	}
	return native.BytesStringPtr(result)
}

//export OpenApiChannels
func OpenApiChannels(guildID *C.char) uintptr {
	result, err := api.Channels(native.DeepCopyString(C.GoString(guildID)))
	if err != nil {
		return 0
	}
	return native.BytesStringPtr(result)
}

//export OpenApiPostChannel
func OpenApiPostChannel(guildID, channelValueObjetJson *C.char) uintptr {
	result, err := api.PostChannel(
		native.DeepCopyString(C.GoString(guildID)),
		native.DeepCopyString(C.GoString(channelValueObjetJson)),
	)

	if err != nil {
		return 0
	}
	return native.BytesStringPtr(result)
}

//export OpenApiPatchChannel
func OpenApiPatchChannel(guildID, channelValueObjetJson *C.char) uintptr {
	result, err := api.PatchChannel(
		native.DeepCopyString(C.GoString(guildID)),
		native.DeepCopyString(C.GoString(channelValueObjetJson)),
	)

	if err != nil {
		return 0
	}
	return native.BytesStringPtr(result)
}

//export OpenApiDeleteChannel
func OpenApiDeleteChannel(channelID *C.char) int8 {
	success, err := api.DeleteChannel(
		native.DeepCopyString(C.GoString(channelID)),
	)

	if err != nil {
		return -1
	} else if success {
		return 1
	} else {
		return 0
	}
}

//export OpenApiMe
func OpenApiMe() uintptr {
	result, err := api.Me()

	if err != nil {
		return 0
	}
	return native.BytesStringPtr(result)
}

//export OpenApiMeGuilds
func OpenApiMeGuilds(pagerJson *C.char) uintptr {
	result, err := api.MeGuilds(
		native.DeepCopyString(C.GoString(pagerJson)),
	)

	if err != nil {
		return 0
	}
	return native.BytesStringPtr(result)
}

//export OpenApiMemberAddRole
func OpenApiMemberAddRole(guildID, roleID, userID, valueJson *C.char) int8 {
	success, err := api.MemberAddRole(
		native.DeepCopyString(C.GoString(guildID)),
		native.DeepCopyString(C.GoString(roleID)),
		native.DeepCopyString(C.GoString(userID)),
		native.DeepCopyString(C.GoString(valueJson)),
	)
	if err != nil {
		return -1
	} else if success {
		return 1
	} else {
		return 0
	}
}

//export OpenApiMemberDeleteRole
func OpenApiMemberDeleteRole(guildID, roleID, userID, valueJson *C.char) int8 {
	success, err := api.MemberDeleteRole(
		native.DeepCopyString(C.GoString(guildID)),
		native.DeepCopyString(C.GoString(roleID)),
		native.DeepCopyString(C.GoString(userID)),
		native.DeepCopyString(C.GoString(valueJson)),
	)

	if err != nil {
		return -1
	} else if success {
		return 1
	} else {
		return 0
	}
}

//export OpenApiMemberMute
func OpenApiMemberMute(guildID, userID, muteJson *C.char) int8 {
	success, err := api.MemberMute(
		native.DeepCopyString(C.GoString(guildID)),
		native.DeepCopyString(C.GoString(userID)),
		native.DeepCopyString(C.GoString(muteJson)),
	)

	if err != nil {
		return -1
	} else if success {
		return 1
	} else {
		return 0
	}
}

func main() {
	fmt.Println("CoreGo Main")
}
