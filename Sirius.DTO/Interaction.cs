using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sirius.DTO
{
    /// <summary>
    /// 互动行为对象
    /// </summary>
    public class Interaction
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        [JsonPropertyName("application_id")]
        public string? ApplicationId { get; set; }

        /// <summary>
        /// 互动类型
        /// </summary>
        [JsonPropertyName("type")]
        public InteractionType? Type { get; set; }

        /// <summary>
        /// 互动数据
        /// </summary>
        [JsonPropertyName("data")]
        public InteractionData? Data { get; set; }

        /// <summary>
        /// 版本，默认为 1
        /// </summary>
        [JsonPropertyName("version")]
        public UInt32? Version { get; set; }
    }

    /// <summary>
    /// 互动数据
    /// </summary>
    public class InteractionData
    {
        /// <summary>
        /// 标题
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// 数据类型，不同数据类型对应不同的 resolved 数据
        /// </summary>
        [JsonPropertyName("type")]
        public InteractionDataType? Type { get; set; }

        /// <summary>
        /// 跟不同的互动类型和数据类型有关系的数据
        /// </summary>
        [JsonPropertyName("resolved")]
        public string? Resolved { get; set; }
    }

    /// <summary>
    /// 互动类型
    /// </summary>
    public enum InteractionType : UInt32
    {
        /// <summary>
        /// ping
        /// </summary>
        Ping = 1,
        /// <summary>
        /// 命令
        /// </summary>
        Command = 2,
    }

    /// <summary>
    /// 互动数据类型
    /// </summary>
    public enum InteractionDataType : UInt32
    {
        /// <summary>
        /// 聊天框搜索
        /// </summary>
        ChatSearch = 9,
    }
}
