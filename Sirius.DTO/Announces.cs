using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sirius.DTO
{
    /// <summary>
    /// 公告对象
    /// </summary>
    public class Announces
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
        /// 用来创建公告的消息ID
        /// </summary>
        [JsonPropertyName("message_id")]
        public string MessageId { get; set; } = string.Empty;

    }

    public class ChannelAnnouncesToCreate
    {
        /// <summary>
        /// 用来创建公告的消息ID
        /// </summary>
        [JsonPropertyName("message_id")]
        public string MessageId { get; set; } = string.Empty;
    }

    public class GuildAnnouncesToCreate
    {
        /// <summary>
        /// 用来创建公告的子频道ID
        /// </summary>
        [JsonPropertyName("channel_id")]
        public string ChannelId { get; set; } = string.Empty;

        /// <summary>
        /// 用来创建公告的消息ID
        /// </summary>
        [JsonPropertyName("message_id")]
        public string MessageId { get; set; } = string.Empty;
    }
}
