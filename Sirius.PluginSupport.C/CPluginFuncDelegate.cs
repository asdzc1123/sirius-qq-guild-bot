using PInvoke;
using Sirius.CoreGoForCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.PluginSupport.C
{
    internal class CPluginFuncDelegate
    {
        private class OpenAPI
        {
            public delegate string Message(string channelId, string msgId);
            public delegate string Messages(string channelId, string pagerJson);
            public delegate string PostMessage(string channelId, string msgJson);
            public delegate bool RetractMessage(string channelId, string msgId);
            public delegate string Guild(string guildId);
            public delegate string GuildMember(string guildId, string userId);
            public delegate string GuildMembers(string guildId, string pagerJson);
            public delegate bool DeleteGuildMember(string guildId, string userId);
            public delegate bool GuildMute(string guildId, string muteJson);
            public delegate string Channel(string channelId);
            public delegate string Channels(string guildId);
            public delegate string PostChannel(string guildId, string channelValueObjetJson);
            public delegate string PatchChannel(string guildId, string channelValueObjetJson);
            public delegate bool DeleteChannel(string channelId);
            public delegate string Me();
            public delegate string MeGuilds(string guildId);
            public delegate bool MemberAddRole(string guildId, string roleId, string userId, string valueJson);
            public delegate bool MemberDeleteRole(string guildId, string roleId, string userId, string valueJson);
            public delegate bool MemberMute(string guildId, string userId, string muteJson);

        }
        private CPluginFuncDelegate() { }

        [StructLayout(LayoutKind.Sequential)]
        public struct COpenAPI
        {
            private IntPtr MessageFunc;
            private IntPtr MessagesFunc;
            private IntPtr PostMessageFunc;
            private IntPtr RetractMessageFunc;
            private IntPtr GuildFunc;
            private IntPtr GuildMemberFunc;
            private IntPtr GuildMembersFunc;
            private IntPtr DeleteGuildMemberFunc;
            private IntPtr GuildMuteFunc;
            private IntPtr ChannelFunc;
            private IntPtr ChannelsFunc;
            private IntPtr PostChannelFunc;
            private IntPtr PatchChannelFunc;
            private IntPtr DeleteChannelFunc;
            private IntPtr MeFunc;
            private IntPtr MeGuildsFunc;
            private IntPtr MemberAddRoleFunc;
            private IntPtr MemberDeleteRoleFunc;
            private IntPtr MemberMute;

            public static COpenAPI New() => new()
            {
                MessageFunc = Marshal.GetFunctionPointerForDelegate<OpenAPI.Message>(CoreGo.OpenAPI.Message),
                MessagesFunc = Marshal.GetFunctionPointerForDelegate<OpenAPI.Messages>(CoreGo.OpenAPI.Messages),
                PostMessageFunc = Marshal.GetFunctionPointerForDelegate<OpenAPI.PostMessage>(CoreGo.OpenAPI.PostMessage),
                RetractMessageFunc = Marshal.GetFunctionPointerForDelegate<OpenAPI.RetractMessage>(CoreGo.OpenAPI.RetractMessage),
                GuildFunc = Marshal.GetFunctionPointerForDelegate<OpenAPI.Guild>(CoreGo.OpenAPI.Guild),
                GuildMemberFunc = Marshal.GetFunctionPointerForDelegate<OpenAPI.GuildMember>(CoreGo.OpenAPI.GuildMember),
                GuildMembersFunc = Marshal.GetFunctionPointerForDelegate<OpenAPI.GuildMembers>(CoreGo.OpenAPI.GuildMembers),
                DeleteGuildMemberFunc = Marshal.GetFunctionPointerForDelegate<OpenAPI.DeleteGuildMember>(CoreGo.OpenAPI.DeleteGuildMember),
                GuildMuteFunc = Marshal.GetFunctionPointerForDelegate<OpenAPI.GuildMute>(CoreGo.OpenAPI.GuildMute),
                ChannelFunc = Marshal.GetFunctionPointerForDelegate<OpenAPI.Channel>(CoreGo.OpenAPI.Channel),
                ChannelsFunc = Marshal.GetFunctionPointerForDelegate<OpenAPI.Channels>(CoreGo.OpenAPI.Channels),
                PostChannelFunc = Marshal.GetFunctionPointerForDelegate<OpenAPI.PostChannel>(CoreGo.OpenAPI.PostChannel),
                PatchChannelFunc = Marshal.GetFunctionPointerForDelegate<OpenAPI.PatchChannel>(CoreGo.OpenAPI.PatchChannel),
                DeleteChannelFunc = Marshal.GetFunctionPointerForDelegate<OpenAPI.DeleteChannel>(CoreGo.OpenAPI.DeleteChannel),
                MeFunc = Marshal.GetFunctionPointerForDelegate<OpenAPI.Me>(CoreGo.OpenAPI.Me),
                MeGuildsFunc = Marshal.GetFunctionPointerForDelegate<OpenAPI.MeGuilds>(CoreGo.OpenAPI.MeGuilds),
                MemberAddRoleFunc = Marshal.GetFunctionPointerForDelegate<OpenAPI.MemberAddRole>(CoreGo.OpenAPI.MemberAddRole),
                MemberDeleteRoleFunc = Marshal.GetFunctionPointerForDelegate<OpenAPI.MemberDeleteRole>(CoreGo.OpenAPI.MemberDeleteRole),
                MemberMute = Marshal.GetFunctionPointerForDelegate<OpenAPI.MemberMute>(CoreGo.OpenAPI.MemberMute),
            };
        }

        public delegate void OnStart();

        public delegate void OnStop();

        public delegate void InitOpenApi(ref COpenAPI api);

        public delegate void OnGuildEvent(string dataJson);

        public delegate void OnGuildMemberEvent(string dataJson);

        public delegate void OnChannelEvent(string dataJson);

        public delegate void OnMessageEvent(string dataJson);

        public delegate void OnMessageReactionEvent(string dataJson);

        public delegate void OnATMessageEvent(string dataJson);

        public delegate void OnDirectMessageEvent(string dataJson);

        public delegate void OnAudioEvent(string dataJson);
    }
}
