using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.CoreCSharp
{
    public class BotEvents
    {
        /// <summary>
        /// 启用频道事件
        /// </summary>
        public bool EnableGuildEvent { get; set; } = true;

        /// <summary>
        /// 启用频道成员事件
        /// </summary>
        public bool EnableGuildMemberEvent { get; set; } = true;

        /// <summary>
        /// 启用子频道事件
        /// </summary>
        public bool EnableChennelEvent { get; set; } = true;

        /// <summary>
        /// 启用消息事件
        /// </summary>
        public bool EnableMessageEvent { get; set; } = false;

        /// <summary>
        /// 启用表情表态事件
        /// </summary>
        public bool EnableMessageReactionEvent { get; set; } = false;

        /// <summary>
        /// 启用@机器人消息事件
        /// </summary>
        public bool EnableATMessageEvent { get; set; } = true;

        /// <summary>
        /// 启用私信消息事件
        /// </summary>
        public bool EnableDirectMessageEvent { get; set; } = false;

        /// <summary>
        /// 启用音频事件
        /// </summary>
        public bool EnableAudioEvent { get; set; } = false;
    }
}
