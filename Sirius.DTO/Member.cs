using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sirius.DTO
{
    /// <summary>
    /// 群成员
    /// </summary>
    public class Member
    {
        [JsonPropertyName("guild_id")]
        public string GuildId { get; set; } = string.Empty;

        [JsonPropertyName("joined_at")]
        public string JoinedAt { get; set; } = string.Empty;

        /// <summary>
        /// 昵称
        /// </summary>
        [JsonPropertyName("nick")]
        public string Nick { get; set; } = string.Empty;

        [JsonPropertyName("user")]
        public User? User { get; set; }

        [JsonPropertyName("roles")]
        public string[] Roles { get; set; } = Array.Empty<string>();

        [JsonPropertyName("deaf")]
        public bool Deaf { get; set; }

        /// <summary>
        /// 是否被禁言
        /// </summary>
        [JsonPropertyName("mute")]
        public bool Mute { get; set; }
    }
}
