using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sirius.DTO
{
    public class WSPaylod
    {
        [JsonPropertyName("op")]
        public OPCode OPCode { get; set; }

        [JsonPropertyName("s")]
        public uint Seq { get; set; }

        [JsonPropertyName("t")]
        public string Type { get; set; } = string.Empty;
    }


    public enum OPCode : int
    {
        Dispatch = 0,
        Heartbeat = 1,
        Identify = 2,
        Resume = 6,
        Reconnect = 7,
        InvalidSession = 9,
        Hello = 10,
        HeartbeatACK = 11,
    }

    public enum EventType
    {

    }
}
