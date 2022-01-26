using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sirius.DTO
{
    /// <summary>
    /// 频道结构定义
    /// </summary>
    public class Guild
    {
        /// <summary>
        /// 频道ID（与客户端上看到的频道ID不同）
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// 频道名称
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 频道头像
        /// </summary>
        [JsonPropertyName("icon")]
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// 拥有者ID
        /// </summary>
        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; } = string.Empty;

        /// <summary>
        /// 是否为拥有者
        /// </summary>
        [JsonPropertyName("owner")]
        public bool IsOwner { get; set; }

        /// <summary>
        /// 成员数量
        /// </summary>
        [JsonPropertyName("member_count")]
        public int MemberCount { get; set; }

        /// <summary>
        /// 最大成员数目
        /// </summary>
        [JsonPropertyName("max_members")]
        public long MaxMembers { get; set; }

        /// <summary>
        /// 频道描述
        /// </summary>
        [JsonPropertyName("description")]
        public string Desc { get; set; } = string.Empty;

        /// <summary>
        /// 当前用户加入群的时间
        /// 此字段只在GUILD_CREATE事件中使用
        /// </summary>
        [JsonPropertyName("joined_at")]
        public string JoinedAt { get; set; } = string.Empty;

        /// <summary>
        /// 当前用户加入群的时间
        /// 此字段只在GUILD_CREATE事件中使用
        /// </summary>
        [JsonPropertyName("channels")]
        public Channel[] Channels { get; set; } = Array.Empty<Channel>();

        /// <summary>
        /// 游戏绑定公会区服ID
        /// </summary>
        [JsonPropertyName("union_world_id")]
        public string UnionWorldId { get; set; } = string.Empty;

        /// <summary>
        /// 游戏绑定公会/战队ID
        /// </summary>
        [JsonPropertyName("union_org_id")]
        public string UnionOrgId { get; set; } = string.Empty;
    }
}
