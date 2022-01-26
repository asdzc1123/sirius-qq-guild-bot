package api

import (
	"encoding/json"
	"github.com/tencent-connect/botgo/dto"
	"sirius-core/core/global"
)

// Guild 获取频道信息
func Guild(guildID string) ([]byte, error) {
	result, err := global.Api.Guild(global.Ctx, guildID)
	if err != nil {
		apiLogger.Error("调用失败", err)
		return nil, err
	}

	resultJson, err := json.Marshal(result)
	if err != nil {
		apiLogger.Error("JSON返回值编码失败", err)
		return nil, err
	}
	apiLogger.Successf("获取频道信息 [频道ID:%s]", guildID)
	return resultJson, nil
}

// GuildMember 获取频道成员
func GuildMember(guildID, userID string) ([]byte, error) {
	result, err := global.Api.GuildMember(global.Ctx, guildID, userID)
	if err != nil {
		apiLogger.Error("调用失败", err)
		return nil, err
	}

	resultJson, err := json.Marshal(result)
	if err != nil {
		apiLogger.Error("返回值编码失败", err)
		return nil, err
	}
	apiLogger.Successf("获取频道成员 [频道ID:%s] [用户ID:%s] ", guildID, userID)
	return resultJson, nil
}

// GuildMembers 获取频道成员数组
func GuildMembers(guildID, pagerJson string) ([]byte, error) {
	var pager *dto.GuildMembersPager

	err := json.Unmarshal([]byte(pagerJson), &pager)

	if err != nil {
		apiLogger.Error("JSON参数解码失败", err)
		return nil, err
	}

	result, err := global.Api.GuildMembers(global.Ctx, guildID, pager)

	resultJson, err := json.Marshal(result)
	if err != nil {
		apiLogger.Error("返回值JSON编码失败", err)
		return nil, err
	}

	apiLogger.Successf("获取频道成员数组 [频道ID]", guildID)
	return resultJson, err
}

// DeleteGuildMember 删除频道成员
func DeleteGuildMember(guildID, userID string) (bool, error) {
	err := global.Api.DeleteGuildMember(global.Ctx, guildID, userID)
	if err != nil {
		apiLogger.Error("调用失败", err)
		return false, err
	} else {
		apiLogger.Successf("删除频道成员 [频道ID:%s] [用户ID:%s]", guildID, userID)
		return true, nil
	}

}

// GuildMute 频道禁言
func GuildMute(guildID, muteJson string) (bool, error) {
	var mute *dto.UpdateGuildMute

	err := json.Unmarshal([]byte(muteJson), &mute)

	if err != nil {
		apiLogger.Error("JSON参数解码失败",err)
		return false, err
	}
	err = global.Api.GuildMute(global.Ctx, guildID, mute)
	if err != nil {
		apiLogger.Error("调用失败", err)
		return false, err
	} else {
		apiLogger.Successf("频道禁言 [频道ID:%s]", guildID)
		return true, nil
	}
}
