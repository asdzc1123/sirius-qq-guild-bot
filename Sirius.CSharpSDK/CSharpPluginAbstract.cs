using Sirius.PluginSupport;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.CSharpSDK
{
    public abstract class CSharpPluginAbstract : IBotEvent
    {
        private readonly IOpenAPI? api;
        public IOpenAPI API { get => api!; }

        private readonly IPluginLogger? logger;
        public IPluginLogger Logger { get => logger!; }

        /// <summary>
        /// 插件名称
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// 插件作者
        /// </summary>
        public abstract string Author { get; }

        /// <summary>
        /// 插件版本
        /// </summary>
        public abstract string Version { get; }

        /// <summary>
        /// 插件启动(加载)时调用
        /// </summary>
        public abstract void OnStart();

        /// <summary>
        /// 插件停止(卸载)时调用
        /// </summary>
        public abstract void OnStop();

        /// <summary>
        /// 频道事件
        /// </summary>
        /// <param name="data"></param>
        public abstract void OnGuildEvent(DTO.Guild data);

        /// <summary>
        /// 频道成员事件
        /// </summary>
        /// <param name="data"></param>
        public abstract void OnGuildMemberEvent(DTO.Member data);

        /// <summary>
        /// 子频道事件
        /// </summary>
        /// <param name="data"></param>
        public abstract void OnChannelEvent(DTO.Channel data);

        /// <summary>
        /// 消息事件
        /// </summary>
        /// <param name="data"></param>
        public abstract void OnMessageEvent(DTO.Message data);

        /// <summary>
        /// 表情表态事件
        /// </summary>
        /// <param name="data"></param>
        public abstract void OnMessageReactionEvent(DTO.Message data);

        /// <summary>
        /// @机器人 消息事件
        /// </summary>
        /// <param name="data"></param>
        public abstract void OnATMessageEvent(DTO.Message data);

        /// <summary>
        /// 私信消息事件
        /// </summary>
        /// <param name="data"></param>
        public abstract void OnDirectMessageEvent(DTO.Message data);

        /// <summary>
        /// 音频机器人事件
        /// </summary>
        /// <param name="data"></param>
        public abstract void OnAudioEvent(DTO.AudioAction data);
    }

}
