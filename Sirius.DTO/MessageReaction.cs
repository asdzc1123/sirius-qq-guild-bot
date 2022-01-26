using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sirius.DTO
{
    /// <summary>
    /// 表情表态动作
    /// </summary>
    public class MessageReaction
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; } = string.Empty;

        [JsonPropertyName("channel_id")]
        public string ChannelId { get; set; } = string.Empty;

        [JsonPropertyName("guild_id")]
        public string GuildId { get; set; } = string.Empty;

        [JsonPropertyName("target")]
        public ReactionTarget Target { get; set; } = new();

        [JsonPropertyName("emoji")]
        public Emoji Emoji { get; set; } = new();
    }

    public class ReactionTarget
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public ReactionTargetType Type { get; set; }
    }

    public enum ReactionTargetType : int
    {
        /// <summary>
        /// 消息
        /// </summary>
        Msg = 0,
        /// <summary>
        /// 帖子
        /// </summary>
        Feed = 1,
        /// <summary>
        /// 评论
        /// </summary>
        Comment = 2,
        /// <summary>
        /// 回复
        /// </summary>
        Reply = 3,
    }
}
