using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sirius.DTO
{
    /// <summary>
    /// 更新频道相关禁言的Body参数
    /// </summary>
    public class UpdateGuildMute
    {
        /// <summary>
        /// 禁言截止时间戳，单位秒
        /// </summary>
        [JsonPropertyName("mute_end_timestamp")]
        public string? MuteEndTimestamp { get; set; }
        /// <summary>
        /// 禁言多少秒（两个字段二选一，默认以mute_end_timstamp为准）
        /// </summary>
        [JsonPropertyName("mute_seconds")]
        public string? MuteSeconds { get; set; }
    }
}
