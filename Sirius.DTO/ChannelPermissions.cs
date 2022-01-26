using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sirius.DTO
{
    /// <summary>
    /// 子频道权限
    /// </summary>
    public class ChannelPermissions
    {
        [JsonPropertyName("channel_id")]
        public string? ChannelId { get; set; }

        [JsonPropertyName("user_id")]
        public string? UserId { get; set; }

        [JsonPropertyName("permissions")]
        public string? Permissions { get; set; }
    }

    /// <summary>
    /// 子频道身份组权限
    /// </summary>
    public class ChannelRolesPermissions
    {
        [JsonPropertyName("channel_id")]
        public string? ChannelId { get; set; }

        [JsonPropertyName("role_id")]
        public string? RoleId { get; set; }

        [JsonPropertyName("permissions")]
        public string? Permissions { get; set; }
    }

    /// <summary>
    /// 修改子频道权限参数
    /// </summary>
    public class UpdateChannelPermissions
    {
        [JsonPropertyName("add")]
        public string? Add { get; set; }

        [JsonPropertyName("remove")]
        public string? Remove { get; set; }
    }
}
