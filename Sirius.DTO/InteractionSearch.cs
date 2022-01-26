using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sirius.DTO
{
    using LayoutType = Int32;
    using ActionType = Int32;

    /// <summary>
    /// 搜索类型的输入数据
    /// </summary>
    public class SearchInputResolved
    {
        [JsonPropertyName("name")]
        public string? Keyword { get; set; }
    }

    /// <summary>
    /// 搜索返回数据
    /// </summary>
    public class SearchRsp
    {
        [JsonPropertyName("name")]
        public SearchLayout[] Layouts { get; set; } = Array.Empty<SearchLayout>();
    }

    /// <summary>
    /// 搜索结果的布局
    /// </summary>
    public class SearchLayout
    {
        public LayoutType LayoutType { get; set; }

        public ActionType ActionType { get; set; }

        public string Title { get; set; } = String.Empty;

        public SearchRecord[] Records { get; set; } = Array.Empty<SearchRecord>();

    }

    /// <summary>
    /// 每一条搜索结果
    /// </summary>
    public class SearchRecord
    {
        [JsonPropertyName("cover")]
        public string Cover { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("tips")]
        public string Tips { get; set; } = string.Empty;

        [JsonPropertyName("url")]
        public string URL { get; set; } = string.Empty;
    }

    /// <summary>
    /// 布局类型
    /// </summary>
    public enum LayoutTypes : Int32
    {
        /// <summary>
        /// 左图右文
        /// </summary>
        ImageText = 0,
    }

    /// <summary>
    /// 每行数据的点击行为
    /// </summary>
    public enum ActionTypes : Int32
    {
        /// <summary>
        /// 发送 ark 消息
        /// </summary>
        SendARK = 0,
    }
}
