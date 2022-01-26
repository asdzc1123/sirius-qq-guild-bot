using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sirius.DTO
{


    /// <summary>
    /// 频道结构
    /// </summary>
    public class Channel
    {
        /// <summary>
        /// 频道ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// 群ID
        /// </summary>
        [JsonPropertyName("guild_id")]
        public string GuildId { get; set; } = string.Empty;

        /// <summary>
        /// 频道名称
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 频道类型
        /// </summary>
        [JsonPropertyName("type")]
        public ChannelType Type { get; set; }

        /// <summary>
        /// 排序位置
        /// </summary>
        [JsonPropertyName("position")]
        public long Position { get; set; }

        /// <summary>
        /// 父频道的ID
        /// </summary>
        [JsonPropertyName("parent_id")]
        public string ParentId { get; set; } = string.Empty;

        /// <summary>
        /// 拥有者ID
        /// </summary>
        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; } = string.Empty;

        /// <summary>
        /// 子频道子类型
        /// </summary>
        [JsonPropertyName("sub_type")]
        public ChannelSubType SubType { get; set; }
    }

    /// <summary>
    /// 频道的值对象部分
    /// </summary>
    public class ChannelValueObject
    {
        /// <summary>
        /// 频道名称
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 频道类型
        /// </summary>
        [JsonPropertyName("type")]
        public int Type { get; set; }

        /// <summary>
        /// 排序位置
        /// </summary>
        [JsonPropertyName("position")]
        public long Position { get; set; }

        /// <summary>
        /// 父频道的ID
        /// </summary>
        [JsonPropertyName("parent_id")]
        public string ParentId { get; set; } = string.Empty;

        /// <summary>
        /// 拥有者ID
        /// </summary>
        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; } = string.Empty;

        /// <summary>
        /// 子频道子类型
        /// </summary>
        [JsonPropertyName("sub_type")]
        public int SubType { get; set; }

    }

    /// <summary>
    /// 子频道类型
    /// </summary>

    public enum ChannelType : Int32
    {
        Text = 0,
        Voice = 2,
        Category = 4,
        /// <summary>
        /// 直播子频道
        /// </summary>
        Live = 10005,
        /// <summary>
        /// 应用子频道
        /// </summary>
        Application = 10006,
    }

    /// <summary>
    /// 子频道子类型
    /// </summary>
    public enum ChannelSubType : Int32
    {
        /// <summary>
        /// 闲聊，默认子类型
        /// </summary>
        Chat = 0,
        /// <summary>
        /// 公告
        /// </summary>
        Notice = 1,
        /// <summary>
        /// 攻略
        /// </summary>
        Guide = 2,
        /// <summary>
        /// 开黑
        /// </summary>
        TeamGame = 3,
    }

}
