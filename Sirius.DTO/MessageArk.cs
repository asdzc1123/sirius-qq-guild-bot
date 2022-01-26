using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Sirius.DTO
{
    /// <summary>
    /// ark模板消息
    /// </summary>
    public class MessageArk
    {
        [JsonPropertyName("ark")]
        public Ark? Ark { get; set; }
    }

    /// <summary>
    /// 消息模版
    /// </summary>
    public class Ark
    {
        /// <summary>
        /// ark 模版 ID
        /// </summary>
        [JsonPropertyName("template_id")]
        public int? TemplateID { get; set; }

        /// <summary>
        /// ArkKV 数组
        /// </summary>
        [JsonPropertyName("kv")]
        public ArkKV[]? KV { get; set; }
    }

    /// <summary>
    /// Ark 键值对
    /// </summary>
    public class ArkKV
    {
        [JsonPropertyName("kv")]
        public string? Key { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }

        [JsonPropertyName("obj")]
        public ArkObj[]? Obj { get; set; }
    }

    /// <summary>
    /// Ark 对象
    /// </summary>
    public class ArkObj
    {
        [JsonPropertyName("obj_kv")]
        public ArkObjKV[]? ObjKV { get; set; }
    }

    /// <summary>
    /// Ark 对象键值对
    /// </summary>
    public class ArkObjKV
    {
        [JsonPropertyName("kv")]
        public string? Key { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }
}
