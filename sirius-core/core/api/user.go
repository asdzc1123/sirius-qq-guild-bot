package api

import (
	"encoding/json"
	"github.com/tencent-connect/botgo/dto"
	"sirius-core/core/global"
)

// Me 获取自己用户信息
func Me() ([]byte, error) {

	result, err := global.Api.Me(global.Ctx)
	if err != nil {
		apiLogger.Error("调用失败", err)
		return nil, err
	}

	resultJson, err := json.Marshal(result)
	if err != nil {
		apiLogger.Error("JSON返回值编码失败", err)
		return nil, err
	}
	apiLogger.Successf("获取自己用户信息")
	return resultJson, nil
}

// MeGuilds 获取频道里的用户信息
func MeGuilds(pagerJson string) ([]byte, error) {
	var pager *dto.GuildPager
	err := json.Unmarshal([]byte(pagerJson), &pager)

	if err != nil {
		apiLogger.Error("JSON参数解码失败", err)
		return nil, err
	}

	result, err := global.Api.MeGuilds(global.Ctx, pager)
	if err != nil {
		apiLogger.Error("调用失败", err)
		return nil, err
	}

	resultJson, err := json.Marshal(result)
	if err != nil {
		apiLogger.Error("JSON返回值编码失败", err)
		return nil, err
	}
	apiLogger.Successf("获取频道用户信息")
	return resultJson, nil
}
