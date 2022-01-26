using Sirius.CSharpSDK;
using System.Text.RegularExpressions;
using Sirius.DTO;
using Sirius.Utils;
using System.Diagnostics;

namespace TestPlugin
{
    public class PluginMain : CSharpPluginAbstract
    {
        public PluginMain(IOpenAPI api, IPluginLogger logger) : base(api, logger)
        {

        }

        public override string Name => "测试插件名称";
        public override string Author => "小草";
        public override string Version => "0.0.1";

        public override void OnStart()
        {
            Log("插件加载");
        }

        public override void OnStop()
        {
            Log("插件卸载");
        }

        public override void OnATMessageEvent(Message data)
        {
            string content = data.Content;
            if (content.Contains("测试MemberMute"))
            {
                if (api.MemberMute(data.GuildId, data.Author.Id, new()
                {
                    MuteEndTimestamp = Util.GenerateMuteEndTimestamp(10)
                }))
                {
                    api.PostMessage(data.ChannelId, new()
                    {
                        Content = $"禁言:{data.Author.UserName}成功",
                        MsgId = data.Id,
                    });
                }
                else
                {
                    api.PostMessage(data.ChannelId, new()
                    {
                        Content = "禁言失败",
                        MsgId = data.Id,
                    });
                }
            }
        }

        public override void OnGuildEvent(Guild data)
        {

        }

        public override void OnGuildMemberEvent(Member data)
        {

        }

        public override void OnChannelEvent(Channel data)
        {

        }

        public override void OnMessageEvent(Message data)
        {

        }

        public override void OnMessageReactionEvent(Message data)
        {

        }

        public override void OnDirectMessageEvent(Message data)
        {

        }

        public override void OnAudioEvent(AudioAction data)
        {

        }
    }
}