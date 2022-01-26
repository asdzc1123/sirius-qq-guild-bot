
namespace Sirius.CSharpSDK
{
    public interface IOpenAPI
    {
        /// <summary>
        /// 获取消息信息
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="messageId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DTO.Message Message(string channelId, string messageId);
        /// <summary>
        /// 获取消息信息数组
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DTO.Message[] Messages(string channelId, DTO.MessagesPager pager);
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DTO.Message PostMessage(string channelId, DTO.MessageToCreate msg);
        /// <summary>
        /// 撤回消息
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool RetractMessage(string channelId, string msgId);
        /// <summary>
        /// 获取频道信息
        /// </summary>
        /// <param name="guildId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DTO.Guild Guild(string guildId);
        /// <summary>
        /// 获取频道成员信息
        /// </summary>
        /// <param name="guildId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DTO.Member GuildMember(string guildId, string userId);
        /// <summary>
        /// 获取频道成员信息数组
        /// </summary>
        /// <param name="guildId"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DTO.Member GuildMembers(string guildId, DTO.GuildPager pager);
        /// <summary>
        /// 删除频道成员(踢人)
        /// </summary>
        /// <param name="guildId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool DeleteGuildMember(string guildId, string userId);
        /// <summary>
        /// 频道全员禁言
        /// </summary>
        /// <param name="guildId"></param>
        /// <param name="mute"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool GuildMute(string guildId, DTO.UpdateGuildMute mute);
        /// <summary>
        /// 获取子频道信息
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DTO.Channel Channel(string channelId);
        /// <summary>
        /// 获取子频道信息数组
        /// </summary>
        /// <param name="guildId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DTO.Channel[] Channels(string guildId);
        /// <summary>
        /// 添加子频道
        /// </summary>
        /// <param name="guildId"></param>
        /// <param name="channelValueObject"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DTO.Channel PostChannel(string guildId, DTO.ChannelValueObject channelValueObject);
        /// <summary>
        /// 修改子频道
        /// </summary>
        /// <param name="guildId"></param>
        /// <param name="channelValueObject"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DTO.Channel PatchChannel(string guildId, DTO.ChannelValueObject channelValueObject);
        /// <summary>
        /// 删除子频道
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool DeleteChannel(string channelId);
        /// <summary>
        /// 获取自己的用户信息
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DTO.User Me();
        /// <summary>
        /// 获取自己加入的频道数组
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DTO.Guild[] MeGuilds(DTO.GuildPager pager);
        /// <summary>
        /// 成员添加角色
        /// </summary>
        /// <param name="guildId"></param>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool MemberAddRole(string guildId, string roleId, string userId, DTO.MemberAddRoleBody value);
        /// <summary>
        /// 成员删除角色
        /// </summary>
        /// <param name="guildId"></param>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool MemberDeleteRole(string guildId, string roleId, string userId, DTO.MemberAddRoleBody value);
        /// <summary>
        /// 禁言成员
        /// </summary>
        /// <param name="guildId"></param>
        /// <param name="userId"></param>
        /// <param name="mute"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool MemberMute(string guildId, string userId, DTO.UpdateGuildMute mute);
    }
}