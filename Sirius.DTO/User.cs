using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sirius.DTO
{
    public class User
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("username")]
        public string UserName { get; set; } = string.Empty;

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; } = string.Empty;

        [JsonPropertyName("bot")]
        public bool Bot { get; set; }

        /// <summary>
        /// 特殊关联应用的 openid
        /// </summary> 
        [JsonPropertyName("union_openid")]
        public string UnionOpenId { get; set; } = string.Empty;

        /// <summary>
        /// 机器人关联的用户信息，与union_openid关联的应用是同一个
        /// </summary>
        [JsonPropertyName("union_user_account")]
        public string UnionUserAccount { get; set; } = string.Empty;

    }
}
