package api

import (
	"encoding/json"
	"github.com/tencent-connect/botgo/dto"
	"sirius-core/core/global"
)

func MemberAddRole(guildID string, roleID string, userID string, valueJson string) (bool, error) {

	var value *dto.MemberAddRoleBody
	err := json.Unmarshal([]byte(valueJson), &value)

	if err != nil {
		apiLogger.Error("JSON参数解码失败", err)
		return false, err
	}
	err = global.Api.MemberAddRole(global.Ctx, guildID, dto.RoleID(roleID), userID, value)
	if err != nil {
		apiLogger.Error("调用失败", err)
		return false, err
	} else {
		apiLogger.Successf("成员添加身份 [频道ID:%s] [身份ID%s] [用户ID:%s]", guildID, roleID, userID)
		return true, nil
	}
}

func MemberDeleteRole(guildID string, roleID string, userID string, valueJson string) (bool, error) {
	var value *dto.MemberAddRoleBody
	err := json.Unmarshal([]byte(valueJson), &value)

	if err != nil {
		apiLogger.Error("JSON参数解码失败", err)
		return false, err
	}

	err = global.Api.MemberDeleteRole(global.Ctx, guildID, dto.RoleID(roleID), userID, value)
	if err != nil {
		apiLogger.Error("调用失败", err)
		return false, err
	} else {
		apiLogger.Successf("成员删除身份 [频道ID:%s] [身份ID%s] [用户ID:%s]", guildID, roleID, userID)
		return true, nil
	}
}

func MemberMute(guildID string, userID string, muteJson string) (bool, error) {
	var mute *dto.UpdateGuildMute
	err := json.Unmarshal([]byte(muteJson), &mute)

	if err != nil {
		apiLogger.Error("JSON参数解码失败",err)
		return false, err
	}
	err = global.Api.MemberMute(global.Ctx, guildID, userID, mute)
	if err != nil {
		apiLogger.Error("调用失败", err)
		return false, err
	} else {
		apiLogger.Successf("成员禁言 [频道ID:%s][用户ID:%s]", guildID, userID)
		return true, nil
	}
}
