/* Code generated by cmd/cgo; DO NOT EDIT. */

/* package command-line-arguments */


#line 1 "cgo-builtin-export-prolog"

#include <stddef.h> /* for ptrdiff_t below */

#ifndef GO_CGO_EXPORT_PROLOGUE_H
#define GO_CGO_EXPORT_PROLOGUE_H

#ifndef GO_CGO_GOSTRING_TYPEDEF
typedef struct { const char *p; ptrdiff_t n; } _GoString_;
#endif

#endif

/* Start of preamble from import "C" comments.  */




/* End of preamble from import "C" comments.  */


/* Start of boilerplate cgo prologue.  */
#line 1 "cgo-gcc-export-header-prolog"

#ifndef GO_CGO_PROLOGUE_H
#define GO_CGO_PROLOGUE_H

typedef signed char GoInt8;
typedef unsigned char GoUint8;
typedef short GoInt16;
typedef unsigned short GoUint16;
typedef int GoInt32;
typedef unsigned int GoUint32;
typedef long long GoInt64;
typedef unsigned long long GoUint64;
typedef GoInt64 GoInt;
typedef GoUint64 GoUint;
typedef __SIZE_TYPE__ GoUintptr;
typedef float GoFloat32;
typedef double GoFloat64;
typedef float _Complex GoComplex64;
typedef double _Complex GoComplex128;

/*
  static assertion to make sure the file is being used on architecture
  at least with matching size of GoInt.
*/
typedef char _check_for_64_bit_pointer_matching_GoInt[sizeof(void*)==64/8 ? 1:-1];

#ifndef GO_CGO_GOSTRING_TYPEDEF
typedef _GoString_ GoString;
#endif
typedef void *GoMap;
typedef void *GoChan;
typedef struct { void *t; void *v; } GoInterface;
typedef struct { void *data; GoInt len; GoInt cap; } GoSlice;

#endif

/* End of boilerplate cgo prologue.  */

#ifdef __cplusplus
extern "C" {
#endif

extern __declspec(dllexport) void Login(GoUintptr readyFuncAddress, GoUint64 appID, char* accessToken);
extern __declspec(dllexport) void EnableGuildEventHandler(GoUintptr funcAddress);
extern __declspec(dllexport) void EnableGuildMemberEventHandler(GoUintptr funcAddress);
extern __declspec(dllexport) void EnableChannelEventHandler(GoUintptr funcAddress);
extern __declspec(dllexport) void EnableMessageEventHandler(GoUintptr funcAddress);
extern __declspec(dllexport) void EnableMessageReactionEventHandler(GoUintptr funcAddress);
extern __declspec(dllexport) void EnableATMessageEventHandler(GoUintptr funcAddress);
extern __declspec(dllexport) void EnableDirectMessageEventHandler(GoUintptr funcAddress);
extern __declspec(dllexport) void EnableAudioEventHandler(GoUintptr funcAddress);
extern __declspec(dllexport) void StartNetworkPluginServer(GoUint16 bindPort);
extern __declspec(dllexport) void SetGoLogOutputFunc(GoUintptr funcAddress);
extern __declspec(dllexport) void SetOpenApiLogOutputFunc(GoUintptr funcAddress);
extern __declspec(dllexport) GoUintptr OpenApiMessage(char* channelID, char* messageID);
extern __declspec(dllexport) GoUintptr OpenApiMessages(char* channelID, char* pagerJson);
extern __declspec(dllexport) GoUintptr OpenApiPostMessage(char* channelID, char* messageJson);
extern __declspec(dllexport) GoInt8 OpenApiRetractMessage(char* channelID, char* messageID);
extern __declspec(dllexport) GoUintptr OpenApiGuild(char* guildID);
extern __declspec(dllexport) GoUintptr OpenApiGuildMember(char* guildID, char* userID);
extern __declspec(dllexport) GoUintptr OpenApiGuildMembers(char* guildID, char* pagerJson);
extern __declspec(dllexport) GoInt8 OpenApiDeleteGuildMember(char* guildID, char* userID);
extern __declspec(dllexport) GoInt8 OpenApiGuildMute(char* guildID, char* muteJson);
extern __declspec(dllexport) GoUintptr OpenApiChannel(char* channelID);
extern __declspec(dllexport) GoUintptr OpenApiChannels(char* guildID);
extern __declspec(dllexport) GoUintptr OpenApiPostChannel(char* guildID, char* channelValueObjetJson);
extern __declspec(dllexport) GoUintptr OpenApiPatchChannel(char* guildID, char* channelValueObjetJson);
extern __declspec(dllexport) GoInt8 OpenApiDeleteChannel(char* channelID);
extern __declspec(dllexport) GoUintptr OpenApiMe();
extern __declspec(dllexport) GoUintptr OpenApiMeGuilds(char* pagerJson);
extern __declspec(dllexport) GoInt8 OpenApiMemberAddRole(char* guildID, char* roleID, char* userID, char* valueJson);
extern __declspec(dllexport) GoInt8 OpenApiMemberDeleteRole(char* guildID, char* roleID, char* userID, char* valueJson);
extern __declspec(dllexport) GoInt8 OpenApiMemberMute(char* guildID, char* userID, char* muteJson);

#ifdef __cplusplus
}
#endif