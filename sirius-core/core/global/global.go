package global

import (
	"context"
	"github.com/tencent-connect/botgo/openapi"
	"github.com/tencent-connect/botgo/token"
)

var BotToken *token.Token
var Api openapi.OpenAPI
var Ctx = context.Background()

