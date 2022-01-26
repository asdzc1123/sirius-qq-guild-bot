using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sirius.DTO
{
    /// <summary>
    /// 日程对象
    /// </summary>
    public class Schedule
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("start_timestamp")]
        public string? StartTimestamp { get; set; }

        [JsonPropertyName("end_timestamp")]
        public string? EndTimestamp { get; set; }

        [JsonPropertyName("jump_channel_id")]
        public string? JumpChannelID { get; set; }

        [JsonPropertyName("remind_type")]
        public string? RemindType { get; set; }

        [JsonPropertyName("creator")]
        public Member? Creator { get; set; } 
    }

    /// <summary>
    /// 创建、修改日程的中间对象
    /// </summary>
    public class ScheduleWrapper
    {
        [JsonPropertyName("schedule")]
        public Schedule? Schedule { get; set; }
    }
}
