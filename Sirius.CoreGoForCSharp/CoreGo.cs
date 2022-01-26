using System.Runtime.InteropServices;


namespace Sirius.CoreGoForCSharp
{
    public class CoreGo
    {
        private class DLLCoreGo
        {
            [DllImport(@"CoreGo.dll")]
            public static extern void Login(IntPtr readyFuncAddress, ulong appId, IntPtr accessToken);

            [DllImport(@"CoreGo.dll")]
            public static extern void EnableGuildEventHandler(IntPtr funcAddress);

            [DllImport(@"CoreGo.dll")]
            public static extern void EnableGuildMemberEventHandler(IntPtr funcAddress);

            [DllImport(@"CoreGo.dll")]
            public static extern void EnableChannelEventHandler(IntPtr funcAddress);

            [DllImport(@"CoreGo.dll")]
            public static extern void EnableMessageEventHandler(IntPtr funcAddress);

            [DllImport(@"CoreGo.dll")]
            public static extern void EnableMessageReactionEventHandler(IntPtr funcAddress);

            [DllImport(@"CoreGo.dll")]
            public static extern void EnableATMessageEventHandler(IntPtr funcAddress);

            [DllImport(@"CoreGo.dll")]
            public static extern void EnableDirectMessageEventHandler(IntPtr funcAddress);

            [DllImport(@"CoreGo.dll")]
            public static extern void EnableAudioEventHandler(IntPtr funcAddress);

            [DllImport(@"CoreGo.dll")]
            public static extern void StartNetworkPluginServer(ushort bindPort);

            [DllImport(@"CoreGo.dll")]
            public static extern void SetGoLogOutputFunc(IntPtr funcAddress);

            [DllImport(@"CoreGo.dll")]
            public static extern void SetOpenApiLogOutputFunc(IntPtr funcAddress);

            [DllImport(@"CoreGo.dll")]
            public static extern IntPtr OpenApiMessage(IntPtr channelId, IntPtr messageId);

            [DllImport(@"CoreGo.dll")]
            public static extern IntPtr OpenApiMessages(IntPtr channelId, IntPtr pagerJson);

            [DllImport(@"CoreGo.dll")]
            public static extern IntPtr OpenApiPostMessage(IntPtr channelId, IntPtr msgJson);

            [DllImport(@"CoreGo.dll")]
            public static extern sbyte OpenApiRetractMessage(IntPtr channelId, IntPtr messageId);

            [DllImport(@"CoreGo.dll")]
            public static extern IntPtr OpenApiGuild(IntPtr guildId);

            [DllImport(@"CoreGo.dll")]
            public static extern IntPtr OpenApiGuildMember(IntPtr guildId, IntPtr userId);

            [DllImport(@"CoreGo.dll")]
            public static extern IntPtr OpenApiGuildMembers(IntPtr guildId, IntPtr pagerJson);

            [DllImport(@"CoreGo.dll")]
            public static extern sbyte OpenApiDeleteGuildMember(IntPtr guildId, IntPtr userId);

            [DllImport(@"CoreGo.dll")]
            public static extern sbyte OpenApiGuildMute(IntPtr guildId, IntPtr muteJson);

            [DllImport(@"CoreGo.dll")]
            public static extern IntPtr OpenApiChannel(IntPtr channelId);

            [DllImport(@"CoreGo.dll")]
            public static extern IntPtr OpenApiChannels(IntPtr guildId);

            [DllImport(@"CoreGo.dll")]
            public static extern IntPtr OpenApiPostChannel(IntPtr guildId, IntPtr channelValueObjetJson);

            [DllImport(@"CoreGo.dll")]
            public static extern IntPtr OpenApiPatchChannel(IntPtr guildId, IntPtr channelValueObjetJson);

            [DllImport(@"CoreGo.dll")]
            public static extern sbyte OpenApiDeleteChannel(IntPtr channelId);

            [DllImport(@"CoreGo.dll")]
            public static extern IntPtr OpenApiMe();

            [DllImport(@"CoreGo.dll")]
            public static extern IntPtr OpenApiMeGuilds(IntPtr pagerJson);

            [DllImport(@"CoreGo.dll")]
            public static extern sbyte OpenApiMemberAddRole(IntPtr guildId, IntPtr roleId, IntPtr userId, IntPtr valueJson);

            [DllImport(@"CoreGo.dll")]
            public static extern sbyte OpenApiMemberDeleteRole(IntPtr guildId, IntPtr roleId, IntPtr userId, IntPtr valueJson);

            [DllImport(@"CoreGo.dll")]
            public static extern sbyte OpenApiMemberMute(IntPtr guildId, IntPtr userId, IntPtr muteJson);
        }

        public static void Login(IntPtr readyFuncAddress, ulong appId, string accessToken) => DLLCoreGo.Login(readyFuncAddress, appId, Marshal.StringToCoTaskMemUTF8(accessToken));

        /// <summary>
        /// 启用频道事件
        /// </summary>
        /// <param name="funcAddress">处理函数地址</param>
        public static void EnableGuildEventHandler(IntPtr funcAddress) => DLLCoreGo.EnableGuildEventHandler(funcAddress);

        /// <summary>
        /// 启用频道成员事件
        /// </summary>
        /// <param name="funcAddress">处理函数地址</param>
        public static void EnableGuildMemberEventHandler(IntPtr funcAddress) => DLLCoreGo.EnableGuildMemberEventHandler(funcAddress);

        /// <summary>
        /// 启用子频道事件
        /// </summary>
        /// <param name="funcAddress">处理函数地址</param>
        public static void EnableChannelEventHandler(IntPtr funcAddress) => DLLCoreGo.EnableChannelEventHandler(funcAddress);

        /// <summary>
        /// 启用消息事件
        /// </summary>
        /// <param name="funcAddress">处理函数地址</param>
        public static void EnableMessageEventHandler(IntPtr funcAddress) => DLLCoreGo.EnableMessageEventHandler(funcAddress);

        /// <summary>
        /// 启用表情表态事件
        /// </summary>
        /// <param name="funcAddress">处理函数地址</param>
        public static void EnableMessageReactionEventHandler(IntPtr funcAddress) => DLLCoreGo.EnableMessageReactionEventHandler(funcAddress);

        /// <summary>
        /// 启用@机器人消息事件
        /// </summary>
        /// <param name="funcAddress">处理函数地址</param>
        public static void EnableATMessageEventHandler(IntPtr funcAddress) => DLLCoreGo.EnableATMessageEventHandler(funcAddress);

        /// <summary>
        /// 启用私信消息事件
        /// </summary>
        /// <param name="funcAddress">处理函数地址</param>
        public static void EnableDirectMessageEventHandler(IntPtr funcAddress) => DLLCoreGo.EnableDirectMessageEventHandler(funcAddress);

        /// <summary>
        /// 启用音频机器人事件
        /// </summary>
        /// <param name="funcAddress">处理函数地址</param>
        public static void EnableAudioEventHandler(IntPtr funcAddress) => DLLCoreGo.EnableAudioEventHandler(funcAddress);

        /// <summary>
        /// 启动网络插件服务
        /// </summary>
        /// <param name="bindPort">绑定端口</param>
        public static void StartNetworkPluginServer(ushort bindPort) => DLLCoreGo.StartNetworkPluginServer(bindPort);

        public static void SetGoLogOutputFunc(IntPtr funcAddress) => DLLCoreGo.SetGoLogOutputFunc(funcAddress);
        public static void SetOpenApiLogOutputFunc(IntPtr funcAddress) => DLLCoreGo.SetOpenApiLogOutputFunc(funcAddress);

        public class OpenAPI
        {
            /// <summary>
            /// 获取消息信息
            /// </summary>
            /// <param name="channelId"></param>
            /// <param name="msgId"></param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static string Message(string channelId, string msgId)
            {
                IntPtr result = DLLCoreGo.OpenApiMessage(
                    Marshal.StringToCoTaskMemUTF8(channelId), Marshal.StringToCoTaskMemUTF8(msgId)
                );
                if (IntPtr.Zero == result)
                {
                    throw new Exception();
                }
                return Marshal.PtrToStringUTF8(result)!;
            }

            /// <summary>
            /// 获取消息信息(数组)
            /// </summary>
            /// <param name="channelId"></param>
            /// <param name="pagerJson"></param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static string Messages(string channelId, string pagerJson)
            {
                IntPtr result = DLLCoreGo.OpenApiMessages(
                    Marshal.StringToCoTaskMemUTF8(channelId), Marshal.StringToCoTaskMemUTF8(pagerJson)
                );
                if (IntPtr.Zero == result)
                {
                    throw new Exception();
                }
                return Marshal.PtrToStringUTF8(result)!;
            }

            /// <summary>
            /// 发送消息
            /// </summary>
            /// <param name="channelId"></param>
            /// <param name="msgJson"></param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static string PostMessage(string channelId, string msgJson)
            {
                IntPtr result = DLLCoreGo.OpenApiPostMessage(
                    Marshal.StringToCoTaskMemUTF8(channelId), Marshal.StringToCoTaskMemUTF8(msgJson)
                );
                if (IntPtr.Zero == result)
                {
                    throw new Exception();
                }
                return Marshal.PtrToStringUTF8(result)!;
            }

            /// <summary>
            /// 撤回消息
            /// </summary>
            /// <param name="channelId"></param>
            /// <param name="messageId"></param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static bool RetractMessage(string channelId, string messageId)
            {
                sbyte result = DLLCoreGo.OpenApiRetractMessage(
                    Marshal.StringToCoTaskMemUTF8(channelId), Marshal.StringToCoTaskMemUTF8(messageId)
                );
                if (-1 == result)
                {
                    throw new Exception();
                }
                return result == 1;
            }

            /// <summary>
            /// 获取频道信息
            /// </summary>
            /// <param name="guildId"></param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static string Guild(string guildId)
            {
                IntPtr result = DLLCoreGo.OpenApiGuild(
                    Marshal.StringToCoTaskMemUTF8(guildId)
                );
                if (IntPtr.Zero == result)
                {
                    throw new Exception();
                }
                return Marshal.PtrToStringUTF8(result)!;
            }

            /// <summary>
            /// 获取频道成员信息
            /// </summary>
            /// <param name="guildId"></param>
            /// <param name="userId"></param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static string GuildMember(string guildId, string userId)
            {
                IntPtr result = DLLCoreGo.OpenApiGuildMember(
                    Marshal.StringToCoTaskMemUTF8(guildId), Marshal.StringToCoTaskMemUTF8(userId)
                );
                if (IntPtr.Zero == result)
                {
                    throw new Exception();
                }
                return Marshal.PtrToStringUTF8(result)!;
            }

            /// <summary>
            /// 获取频道成员信息(数组)
            /// </summary>
            /// <param name="guildId"></param>
            /// <param name="pagerJson"></param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static string GuildMembers(string guildId, string pagerJson)
            {
                IntPtr result = DLLCoreGo.OpenApiGuildMembers(
                    Marshal.StringToCoTaskMemUTF8(guildId), Marshal.StringToCoTaskMemUTF8(pagerJson)
                 );
                if (IntPtr.Zero == result)
                {
                    throw new Exception();
                }
                return Marshal.PtrToStringUTF8(result)!;
            }

            /// <summary>
            /// 删除频道成员(踢人)
            /// </summary>
            /// <param name="guildId"></param>
            /// <param name="userId"></param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static bool DeleteGuildMember(string guildId, string userId)
            {
                sbyte result = DLLCoreGo.OpenApiDeleteGuildMember(
                    Marshal.StringToCoTaskMemUTF8(guildId), Marshal.StringToCoTaskMemUTF8(userId)
                );
                if (-1 == result)
                {
                    throw new Exception();
                }
                return result == 1;
            }

            /// <summary>
            /// 频道全员禁言
            /// </summary>
            /// <param name="guildId"></param>
            /// <param name="muteJson"></param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static bool GuildMute(string guildId, string muteJson)
            {
                sbyte result = DLLCoreGo.OpenApiGuildMute(
                    Marshal.StringToCoTaskMemUTF8(guildId), Marshal.StringToCoTaskMemUTF8(muteJson)
                );

                if (-1 == result)
                {
                    throw new Exception();
                }
                return result == 1;
            }

            /// <summary>
            /// 获取子频道信息
            /// </summary>
            /// <param name="channelId"></param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static string Channel(string channelId)
            {
                IntPtr result = DLLCoreGo.OpenApiChannel(
                    Marshal.StringToCoTaskMemUTF8(channelId)
                );
                if (IntPtr.Zero == result)
                {
                    throw new Exception();
                }
                return Marshal.PtrToStringUTF8(result)!;
            }

            /// <summary>
            /// 获取子频道信息(数组)
            /// </summary>
            /// <param name="guildId"></param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static string Channels(string guildId)
            {
                IntPtr result = DLLCoreGo.OpenApiChannels(
                    Marshal.StringToCoTaskMemUTF8(guildId)
                );
                if (IntPtr.Zero == result)
                {
                    throw new Exception();
                }
                return Marshal.PtrToStringUTF8(result)!;
            }

            /// <summary>
            /// 添加子频道
            /// </summary>
            /// <param name="guildId"></param>
            /// <param name="channelValueObjetJson"></param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static string PostChannel(string guildId, string channelValueObjetJson)
            {

                IntPtr result = DLLCoreGo.OpenApiPostChannel(
                    Marshal.StringToCoTaskMemUTF8(guildId), Marshal.StringToCoTaskMemUTF8(channelValueObjetJson)
                );
                if (IntPtr.Zero == result)
                {
                    throw new Exception();
                }
                return Marshal.PtrToStringUTF8(result)!;
            }

            /// <summary>
            /// 修改子频道
            /// </summary>
            /// <param name="guildId"></param>
            /// <param name="channelValueObjetJson"></param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static string PatchChannel(string guildId, string channelValueObjetJson)
            {
                IntPtr result = DLLCoreGo.OpenApiPatchChannel(
                    Marshal.StringToCoTaskMemUTF8(guildId), Marshal.StringToCoTaskMemUTF8(channelValueObjetJson)
                );
                if (IntPtr.Zero == result)
                {
                    throw new Exception();
                }
                return Marshal.PtrToStringUTF8(result)!;
            }

            /// <summary>
            /// 删除子频道
            /// </summary>
            /// <param name="channelId"></param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static bool DeleteChannel(string channelId)
            {
                sbyte result = DLLCoreGo.OpenApiDeleteChannel(
                    Marshal.StringToCoTaskMemUTF8(channelId)
                );
                if (-1 == result)
                {
                    throw new Exception();
                }
                return result == 1;
            }

            /// <summary>
            /// 获取自己的用户信息
            /// </summary>
            /// <returns></returns>
            public static string Me()
            {
                return Marshal.PtrToStringUTF8(DLLCoreGo.OpenApiMe())!;
            }

            /// <summary>
            /// 获取自己加入的频道信息(数组)
            /// </summary>
            /// <param name="pagerJson"></param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static string MeGuilds(string pagerJson)
            {
                IntPtr result = DLLCoreGo.OpenApiMeGuilds(
                    Marshal.StringToCoTaskMemUTF8(pagerJson)
                );
                if (IntPtr.Zero == result)
                {
                    throw new Exception();
                }
                return Marshal.PtrToStringUTF8(result)!;
            }

            public static bool MemberAddRole(string guildId, string roleId, string userId, string valueJson)
            {
                sbyte result = DLLCoreGo.OpenApiMemberAddRole(
                    Marshal.StringToCoTaskMemUTF8(guildId), Marshal.StringToCoTaskMemUTF8(roleId), Marshal.StringToCoTaskMemUTF8(userId), Marshal.StringToCoTaskMemUTF8(valueJson)
                );
                if (-1 == result)
                {
                    throw new Exception();
                }
                return result == 1;
            }

            public static bool MemberDeleteRole(string guildId, string roleId, string userId, string valueJson)
            {
                sbyte result = DLLCoreGo.OpenApiMemberDeleteRole(
                    Marshal.StringToCoTaskMemUTF8(guildId), Marshal.StringToCoTaskMemUTF8(roleId), Marshal.StringToCoTaskMemUTF8(userId), Marshal.StringToCoTaskMemUTF8(valueJson)
                );
                if (-1 == result)
                {
                    throw new Exception();
                }
                return result == 1;
            }

            public static bool MemberMute(string guildId, string userId, string muteJson)
            {
                sbyte result = DLLCoreGo.OpenApiMemberMute(
                    Marshal.StringToCoTaskMemUTF8(guildId), Marshal.StringToCoTaskMemUTF8(userId), Marshal.StringToCoTaskMemUTF8(muteJson)
                );
                if (-1 == result)
                {
                    throw new Exception();
                }
                return result == 1;
            }
        }
    }
}
