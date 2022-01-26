using System.Text.Json.Serialization;

namespace Sirius.DTO
{
    /// <summary>
    /// 频道用户组列表返回
    /// </summary>
    public class GuildRoles
    {
        [JsonPropertyName("guild_id")]
        public string GuildId { get; set; } = string.Empty;

        [JsonPropertyName("roles")]
        public Role[] Roles { get; set; } = Array.Empty<Role>();

        [JsonPropertyName("role_num_limit")]
        public string NumLimit { get; set; } = string.Empty;
    }

    /// <summary>
    /// 频道身份组
    /// </summary>
    public class Role
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public UInt32 Name { get; set; }

        [JsonPropertyName("color")]
        public UInt32 Color { get; set; }

        [JsonPropertyName("hoist")]
        public UInt32 Hoist { get; set; }

        /// <summary>
        /// 不会被修改，创建接口修改
        /// </summary>
        [JsonPropertyName("number")]
        public UInt32? MemberCount { get; set; }

        /// <summary>
        /// 不会被修改，创建接口修改
        /// </summary>
        [JsonPropertyName("member_limit")]
        public UInt32? MemberLimit { get; set; }
    }

    /// <summary>
    /// 身份组可更改数据
    /// </summary>
    public class UpdateRoleInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("color")]
        public UInt32 Color { get; set; }

        [JsonPropertyName("hoist")]
        public UInt32 Hoist { get; set; }
    }

    /// <summary>
    /// 身份组可更改数据，修改的
    /// </summary>
    public class UpdateRoleFilter
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("color")]
        public UInt32 Color { get; set; }

        [JsonPropertyName("hoist")]
        public UInt32 Hoist { get; set; }
    }

    /// <summary>
    /// role 更新请求承载
    /// </summary>
    public class UpdateRole
    {
        [JsonPropertyName("guild_id")]
        public string GuildId { get; set; } = string.Empty;

        [JsonPropertyName("filter")]
        public UpdateRoleFilter Filter { get; set; } = new();

        [JsonPropertyName("update")]
        public Role Update { get; set; } = new();
    }

    /// <summary>
    /// 创建，删除等行为的返回
    /// </summary>
    public class UpdateResult
    {
        [JsonPropertyName("role_id")]
        public string RoleId { get; set; } = string.Empty;

        [JsonPropertyName("guild_id")]
        public string GuildId { get; set; } = string.Empty;

        [JsonPropertyName("role")]
        public Role Role { get; set; } = new();
    }

    /// <summary>
    /// 增加子频道管理员身份组时附加内容
    /// </summary>
    public class MemberAddRoleBody
    {
        [JsonPropertyName("channel")]
        public Channel Channel { get; set; } = new();
    }
}
