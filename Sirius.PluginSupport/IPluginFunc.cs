using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.PluginSupport
{
    public interface IPluginFunc
    {
        public void OnStart();
        public void OnStop();
        public void OnGuildEvent(string dataJson);
        public void OnGuildMemberEvent(string dataJson);
        public void OnChannelEvent(string dataJson);
        public void OnMessageEvent(string dataJson);
        public void OnMessageReactionEvent(string dataJson);
        public void OnATMessageEvent(string dataJson);
        public void OnDirectMessageEvent(string dataJson);
        public void OnAudioEvent(string dataJson);
    }
}
