using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sirius.DTO
{
    /// <summary>
    /// 音频控制对象
    /// </summary>
    public class AudioControl
    {
        [JsonPropertyName("audio_url")]
        public string URL { get; set; } = string.Empty;
        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;
        [JsonPropertyName("status")]
        public AudioStatus Status { get; set; }
    }

    /// <summary>
    /// 音频动作
    /// </summary>
    public class AudioAction
    {
        [JsonPropertyName("guild_id")]
        public string GuildId { get; set; } = string.Empty;

        [JsonPropertyName("channel_id")]
        public string ChannelId { get; set; } = string.Empty;

        [JsonPropertyName("audio_url")]
        public string URL { get; set; } = string.Empty;

        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;

    }

    public enum AudioStatus : int
    {
        Start = 0,
        Pause = 1,
        Resume = 2,
        Stop = 3,
    }
}
