using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sirius.DTO
{
    using MessagePagerType = String;
    /// <summary>
    /// 频道成员分页器
    /// </summary>
    public class GuildMembersPager
    {
        /// <summary>
        /// 读此id之后的数据，如果是第一次请求填0，默认为0
        /// </summary>
        [JsonPropertyName("after")]
        public string After { get; set; } = string.Empty;

        /// <summary>
        /// 分页大小，1-1000，默认是1
        /// </summary>
        [JsonPropertyName("limit")]
        public string Limit { get; set; } = string.Empty;
    }

    /// <summary>
    /// 频道分页器
    /// </summary>
    public class GuildPager
    {

        /// <summary>
        /// 读此id之前的数据
        /// </summary>
        [JsonPropertyName("before")]
        public string Before { get; set; } = string.Empty;

        /// <summary>
        /// 读此id之后的数据
        /// </summary>
        [JsonPropertyName("after")]
        public string After { get; set; } = string.Empty;

        /// <summary>
        /// 分页大小，1-100，默认是 100
        /// </summary>
        [JsonPropertyName("limit")]
        public string Limit { get; set; } = string.Empty;
    }

    /// <summary>
    /// 消息分页器
    /// </summary>
    public class MessagesPager
    {
        /// <summary>
        /// 拉取类型
        /// </summary>
        [JsonPropertyName("Type")]
        public MessagePagerType Type { get; set; } = string.Empty;

        /// <summary>
        /// 消息ID
        /// </summary>
        [JsonPropertyName("ID")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// 最大 20
        /// </summary>
        [JsonPropertyName("limit")]
        public string Limit { set; get; } = string.Empty;

    }



    public class MessagePagerTypes
    {
        /// <summary>
        /// 拉取消息ID上下的消息
        /// </summary>
        public static MessagePagerType MPTAround => "around";
        /// <summary>
        /// 拉取消息ID之前的消息
        /// </summary>
        public static MessagePagerType MPTBefore => "before";
        /// <summary>
        /// 拉取消息ID之后的消息
        /// </summary>
        public static MessagePagerType MPTAfter => "after";
    }

}
