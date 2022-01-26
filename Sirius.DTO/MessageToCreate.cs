using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sirius.DTO
{
    /// <summary>
    /// 发送消息结构体定义
    /// </summary>
    public class MessageToCreate
    {
        /// <summary>
        /// 发送含有URL的JSON数据会报错
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;

        [JsonPropertyName("embed")]
        public Embed? Embed { get; set; }

        [JsonPropertyName("ark")]
        public Ark? Ark { get; set; }

        /// <summary>
        /// 一次消息似乎只能发送一张图片
        /// </summary>
        [JsonPropertyName("image")]
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// 要回复的消息id，为空是主动消息，公域机器人会异步审核，不为空是被动消息，公域机器人会校验语料
        /// </summary>
        [JsonPropertyName("msg_id")]
        public string MsgId { get; set; } = string.Empty;
    }
}
