package api

import (
	"encoding/json"
	"github.com/tencent-connect/botgo/dto"
	"github.com/tencent-connect/botgo/log"
	"sirius-core/core/global"
)

// Channel 获取子频道信息
func Channel(channelID string) ([]byte, error) {
	result, err := global.Api.Channel(global.Ctx, channelID)
	if err != nil {
		apiLogger.Error("调用失败", err)
		return nil, err
	}
	resultJson, err := json.Marshal(result)
	if err != nil {
		apiLogger.Error("序列化返回值JSON失败", err)
		return nil, err
	}
	apiLogger.Successf("获取子频道信息 [子频道ID:%s]",channelID)
	return resultJson, nil
}

// Channels 获取子频道数组
func Channels(guildID string) ([]byte, error) {
	result, err := global.Api.Channels(global.Ctx, guildID)
	if err != nil {
		apiLogger.Error("调用失败", err)
		return nil, err
	}

	resultJson, err := json.Marshal(result)
	if err != nil {
		apiLogger.Error("序列化返回值JSON失败", err)
		return nil, err
	}
	apiLogger.Successf("获取子频道信息数组 [频道ID:%s]",guildID)
	return resultJson, nil
}

// PostChannel 创建子频道
func PostChannel(guildID, channelValueObjetJson string) ([]byte, error) {

	var channelValueObjet *dto.ChannelValueObject

	err := json.Unmarshal([]byte(channelValueObjetJson), &channelValueObjet)

	if err != nil {
		apiLogger.Error("JSON参数解码失败", err)
		return nil, err
	}

	result, err := global.Api.PostChannel(global.Ctx, guildID, channelValueObjet)
	if err != nil {
		log.Error(err, "调用失败")
		return nil, err
	}

	resultJson, err := json.Marshal(result)
	if err != nil {
		apiLogger.Error("JSON返回值编码失败", err)
		return nil, err
	}
	apiLogger.Successf("创建子频道 [子频道名称:%s]", channelValueObjet.Name)
	return resultJson, nil
}

// PatchChannel 修改子频道
func PatchChannel(channelID, channelValueObjetJson string) ([]byte, error) {
	var channelValueObjet *dto.ChannelValueObject

	err := json.Unmarshal([]byte(channelValueObjetJson), &channelValueObjet)

	if err != nil {
		apiLogger.Error("JSON参数解码失败", err)
		return nil, err
	}

	result, err := global.Api.PatchChannel(global.Ctx, channelID, channelValueObjet)
	if err != nil {
		apiLogger.Error("调用失败", err)
		return nil, err
	}

	resultJson, err := json.Marshal(result)
	if err != nil {
		apiLogger.Error("JSON返回值编码失败", err)
		return nil, err
	}
	apiLogger.Successf("修改子频道 [子频道名称:%s]", channelValueObjet.Name)
	return resultJson, nil
}

// DeleteChannel 删除子频道
func DeleteChannel(channelID string) (bool, error) {
	err := global.Api.DeleteChannel(global.Ctx, channelID)
	if err != nil {
		apiLogger.Error("调用失败", err)
		return false, err
	} else {
		apiLogger.Successf("删除子频道:%s", channelID)
		return true, nil
	}
}
