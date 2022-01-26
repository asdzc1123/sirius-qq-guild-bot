using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sirius.DTO
{
    /// <summary>
    /// 私信结构定义，一个 DirectMessage 为两个用户之间的一个私信频道，简写为 DM
    /// </summary>
    public class DirectMessage
    {
        /// <summary>
        /// 频道ID
        /// </summary>
        [JsonPropertyName("guild_id")]
        public string GuildId { get; set; } = string.Empty;

        /// <summary>
        /// 子频道ID
        /// </summary>
        [JsonPropertyName("channel_id")]
        public string ChannelId { get; set; } = string.Empty;

        /// <summary>
        /// 私信频道创建的时间戳
        /// </summary>
        [JsonPropertyName("create_time")]
        public string CreateTime { get; set; } = string.Empty;

    }

    /// <summary>
    /// 创建私信频道的结构体定义
    /// </summary>
    public class DirectMessageToCreate
    {
        /// <summary>
        /// 频道ID
        /// </summary>
        [JsonPropertyName("source_guild_id")]
        public string SourceGuildId { get; set; } = string.Empty;

        /// <summary>
        /// 用户ID
        /// </summary>
        [JsonPropertyName("recipient_id")]
        public string RecipientID { get; set; } = string.Empty;
    }
}
