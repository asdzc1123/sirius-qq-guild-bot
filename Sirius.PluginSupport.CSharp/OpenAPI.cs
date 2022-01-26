using Sirius.CoreGoForCSharp;
using Sirius.CSharpSDK;
using Sirius.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.PluginSupport.CSharp
{
    public class OpenAPI
    {


        public static IOpenAPI Instance { get; } = new CSharpOpenAPI();



        public class CSharpOpenAPI : IOpenAPI
        {
            DTO.Message IOpenAPI.Message(string channelId, string msgId)
            {
                string result = CoreGo.OpenAPI.Message(channelId, msgId);
                return Util.JsonDecode<DTO.Message>(result)!;
            }

            DTO.Message[] IOpenAPI.Messages(string channelId, DTO.MessagesPager pager)
            {
                string pagerJson = Util.JsonEncode(pager);
                string result = CoreGo.OpenAPI.Messages(channelId, pagerJson);

                return Util.JsonDecode<DTO.Message[]>(result)!;
            }

            DTO.Message IOpenAPI.PostMessage(string channelId, DTO.MessageToCreate msg)
            {
                string msgJson = Util.JsonEncode(msg);
                string result = CoreGo.OpenAPI.PostMessage(channelId, msgJson);

                return Util.JsonDecode<DTO.Message>(result)!;
            }

            bool IOpenAPI.RetractMessage(string channelId, string messageId)
            {
                return CoreGo.OpenAPI.RetractMessage(channelId, messageId);
            }

            DTO.Guild IOpenAPI.Guild(string guildId)
            {
                string result = CoreGo.OpenAPI.Guild(guildId);

                return Util.JsonDecode<DTO.Guild>(result)!;
            }

            DTO.Member IOpenAPI.GuildMember(string guildId, string userId)
            {

                string result = CoreGo.OpenAPI.GuildMember(guildId, userId);

                return Util.JsonDecode<DTO.Member>(result)!;
            }

            DTO.Member IOpenAPI.GuildMembers(string guildId, DTO.GuildPager pager)
            {
                string pagerJson = Util.JsonEncode(pager);
                string result = CoreGo.OpenAPI.GuildMembers(guildId, pagerJson);

                return Util.JsonDecode<DTO.Member>(result)!;
            }

            bool IOpenAPI.DeleteGuildMember(string guildId, string userId)
            {
                return CoreGo.OpenAPI.DeleteGuildMember(guildId, userId);
            }

            bool IOpenAPI.GuildMute(string guildId, DTO.UpdateGuildMute mute)
            {
                string muteJson = Util.JsonEncode(mute);
                return CoreGo.OpenAPI.GuildMute(guildId, muteJson);
            }

            DTO.Channel IOpenAPI.Channel(string channelId)
            {
                string result = CoreGo.OpenAPI.Channel(channelId);

                return Util.JsonDecode<DTO.Channel>(result)!;
            }

            DTO.Channel[] IOpenAPI.Channels(string guildId)
            {
                string result = CoreGo.OpenAPI.Channels(guildId);

                return Util.JsonDecode<DTO.Channel[]>(result)!;
            }

            DTO.Channel IOpenAPI.PostChannel(string guildId, DTO.ChannelValueObject channelValueObject)
            {
                string channelValueObjectJson = Util.JsonEncode(channelValueObject);
                string result = CoreGo.OpenAPI.PostChannel(guildId, channelValueObjectJson);

                return Util.JsonDecode<DTO.Channel>(result)!;
            }

            DTO.Channel IOpenAPI.PatchChannel(string guildId, DTO.ChannelValueObject channelValueObject)
            {
                string channelValueObjectJson = Util.JsonEncode(channelValueObject);
                string result = CoreGo.OpenAPI.PatchChannel(guildId, channelValueObjectJson);

                return Util.JsonDecode<DTO.Channel>(result)!;
            }

            bool IOpenAPI.DeleteChannel(string channelId)
            {
                return CoreGo.OpenAPI.DeleteChannel(channelId);
            }

            DTO.User IOpenAPI.Me()
            {
                string result = CoreGo.OpenAPI.Me();

                return Util.JsonDecode<DTO.User>(result)!;
            }

            DTO.Guild[] IOpenAPI.MeGuilds(DTO.GuildPager pager)
            {
                string result = CoreGo.OpenAPI.MeGuilds(Util.JsonEncode(pager));

                return Util.JsonDecode<DTO.Guild[]>(result)!;
            }

            bool IOpenAPI.MemberAddRole(string guildId, string roleId, string userId, DTO.MemberAddRoleBody value)
            {
                return CoreGo.OpenAPI.MemberAddRole(guildId, roleId, userId, Util.JsonEncode(value));
            }

            bool IOpenAPI.MemberDeleteRole(string guildId, string roleId, string userId, DTO.MemberAddRoleBody value)
            {
                return CoreGo.OpenAPI.MemberDeleteRole(guildId, roleId, userId, Util.JsonEncode(value));
            }

            bool IOpenAPI.MemberMute(string guildId, string userId, DTO.UpdateGuildMute mute)
            {
                return CoreGo.OpenAPI.MemberMute(guildId, userId, Util.JsonEncode(mute));
            }
        }
    }
}
