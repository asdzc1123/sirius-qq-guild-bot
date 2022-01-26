using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sirius.DTO
{
    /// <summary>
    /// 消息结构体定义
    /// </summary>
    public class Message
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// 子频道ID
        /// </summary>
        [JsonPropertyName("channel_id")]
        public string ChannelId { get; set; } = string.Empty;

        /// <summary>
        /// 频道ID
        /// </summary>
        [JsonPropertyName("guild_id")]
        public string GuildId { get; set; } = string.Empty;

        /// <summary>
        /// 内容
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// 发送时间
        /// </summary>
        [JsonPropertyName("timestamp")]
        public string Timestamp { get; set; } = string.Empty;

        /// <summary>
        /// 消息编辑时间
        /// </summary>
        [JsonPropertyName("edited_timestamp")]
        public string EditedTimestamp { get; set; } = string.Empty;

        /// <summary>
        /// 是否@all
        /// </summary>
        [JsonPropertyName("mention_everyone")]
        public bool MentionEveryone { get; set; }

        /// <summary>
        /// 消息发送方
        /// </summary>
        [JsonPropertyName("author")]
        public User Author { get; set; } = new();

        /// <summary>
        /// 消息发送方Author的member属性，只是部分属性
        /// </summary>
        [JsonPropertyName("member")]
        public Member Member { get; set; } = new();

        /// <summary>
        /// 附件
        /// </summary>
        [JsonPropertyName("attachments")]
        public MessageAttachment[]? Attachments { get; set; }

        /// <summary>
        /// 结构化消息-embeds
        /// </summary>
        [JsonPropertyName("embeds")]
        public Embed[]? Embeds { get; set; }

        /// <summary>
        /// 消息中的提醒信息(@)列表
        /// </summary>
        [JsonPropertyName("mentions")]
        public User[] Mentions { get; set; } = Array.Empty<User>();

        /// <summary>
        /// ark 消息
        /// </summary>
        [JsonPropertyName("ark")]
        public Ark? Ark { get; set; }

        /// <summary>
        /// 私信消息
        /// </summary>
        [JsonPropertyName("direct_message")]
        public bool DirectMessage { get; set; }
    }

    /// <summary>
    /// 结构
    /// </summary>
    public class Embed
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// 消息弹窗内容，消息列表摘要
        /// </summary>
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; } = string.Empty;

        [JsonPropertyName("timestamp")]
        public string Timestamp { get; set; } = string.Empty;

        [JsonPropertyName("fields")]
        public EmbedField[]? Fields;
    }

    /// <summary>
    /// Embed字段描述
    /// </summary>
    public class EmbedField
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

    /// <summary>
    /// 附件定义
    /// </summary>
    public class MessageAttachment
    {
        [JsonPropertyName("url")]
        public string URL { get; set; } = string.Empty;
    }
}
