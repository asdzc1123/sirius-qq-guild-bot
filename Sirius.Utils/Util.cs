using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Sirius.Utils
{
    public class Util
    {
        /// <summary>
        /// 生成禁言结束时间戳
        /// </summary>
        /// <param name="seconds">要禁言的秒数</param>
        /// <returns>时间戳秒的ToString</returns>
        public static string GenerateMuteEndTimestamp(int seconds)
        {
            return (new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds() + seconds).ToString();
        }

        public static T DeepCopyByReflect<T>(T obj)
        {
            //如果是null或值类型则直接返回
            if (obj == null || obj is string || obj.GetType().IsValueType) return obj;

            object retval = Activator.CreateInstance(obj.GetType())!;
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                try { field.SetValue(retval, DeepCopyByReflect(field.GetValue(obj))); }
                catch { }
            }
            return (T)retval;
        }


        private static readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true,
        };


        public static T? JsonDecode<T>(string jsonString)
        {
            return JsonSerializer.Deserialize<T>(jsonString, jsonSerializerOptions);
        }

        public static string JsonEncode<T>(T json)
        {
            return JsonSerializer.Serialize(json, jsonSerializerOptions);
        }
    }
}