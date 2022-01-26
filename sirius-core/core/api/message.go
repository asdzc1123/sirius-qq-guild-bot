package api

import (
	"encoding/json"
	"github.com/tencent-connect/botgo/dto"
	"sirius-core/core/global"
)

// Message 获取消息
func Message(channelID, messageID string) ([]byte, error) {
	result, err := global.Api.Message(global.Ctx, channelID, messageID)
	if err != nil {
		apiLogger.Error("调用失败", err)
		return nil, err
	}

	resultJson, err := json.Marshal(result)
	if err != nil {
		apiLogger.Error("JSON返回值编码失败", err)
		return nil, err
	}
	apiLogger.Successf("获取消息 [子频道ID%s] [消息ID%s]", channelID, messageID)
	return resultJson, nil
}

// Messages 获取消息数组
func Messages(channelID, pagerJson string) ([]byte, error) {
	var pager *dto.MessagesPager

	err := json.Unmarshal([]byte(pagerJson), &pager)

	if err != nil {
		apiLogger.Error("JSON参数解码失败", err)
		return nil, err
	}

	result, err := global.Api.Messages(global.Ctx, channelID, pager)
	if err != nil {
		apiLogger.Error("调用失败", err)
		return nil, err
	}

	resultJson, err := json.Marshal(result)
	if err != nil {
		apiLogger.Error("JSON返回值编码失败", err)
		return nil, err
	}

	return resultJson, nil
}

// PostMessage 发送消息
func PostMessage(channelID, messageJson string) ([]byte, error) {
	var message *dto.MessageToCreate

	err := json.Unmarshal([]byte(messageJson), &message)

	if err != nil {
		apiLogger.Error("JSON参数解码失败", err)
		return nil, err
	}

	result, err := global.Api.PostMessage(global.Ctx, channelID, message)
	if err != nil {
		apiLogger.Error("调用失败", err)
		return nil, err
	}

	resultJson, err := json.Marshal(result)
	if err != nil {
		apiLogger.Error("JSON返回值解码失败", err)
		return nil, err
	}
	apiLogger.Successf("发送消息 [子频道ID:%s] => %s", message.Content)
	return resultJson, nil
}

// RetractMessage 撤回消息
func RetractMessage(channelID, messageID string) (bool, error) {
	err := global.Api.RetractMessage(global.Ctx, channelID, messageID)
	if err != nil {
		apiLogger.Error("调用失败", err)
		return false, err
	} else {
		apiLogger.Successf("撤回消息 [子频道ID:%s][消息ID:%s]", channelID, messageID)
		return true, nil
	}
}
