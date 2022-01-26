using Sirius.CSharpSDK;
using Sirius.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.PluginSupport.CSharp
{
    public class CSharpPluginFunc:IPluginFunc
    {
        private readonly CSharpPluginAbstract instance;

        public CSharpPluginFunc(CSharpPluginAbstract instance)
        {
            this.instance = instance;
        }

        void IPluginFunc.OnStart()
        {
            instance.OnStart();
        }

        void IPluginFunc.OnStop()
        {
            instance.OnStop();
        }

        void IPluginFunc.OnGuildEvent(string dataJson)
        {
            instance.OnGuildEvent(Util.JsonDecode<DTO.Guild>(dataJson)!);
        }

        void IPluginFunc.OnGuildMemberEvent(string dataJson)
        {
            instance.OnGuildMemberEvent(Util.JsonDecode<DTO.Member>(dataJson)!);
        }

        void IPluginFunc.OnChannelEvent(string dataJson)
        {
            instance.OnChannelEvent(Util.JsonDecode<DTO.Channel>(dataJson)!);
        }

        void IPluginFunc.OnMessageEvent(string dataJson)
        {
            instance.OnMessageEvent(Util.JsonDecode<DTO.Message>(dataJson)!);
        }

        void IPluginFunc.OnMessageReactionEvent(string dataJson)
        {
            instance.OnMessageReactionEvent(Util.JsonDecode<DTO.Message>(dataJson)!);
        }

        void IPluginFunc.OnATMessageEvent(string dataJson)
        {
            instance.OnATMessageEvent(Util.JsonDecode<DTO.Message>(dataJson)!);
        }

        void IPluginFunc.OnDirectMessageEvent(string dataJson)
        {
            instance.OnDirectMessageEvent(Util.JsonDecode<DTO.Message>(dataJson)!);
        }

        void IPluginFunc.OnAudioEvent(string dataJson)
        {
            instance.OnAudioEvent(Util.JsonDecode<DTO.AudioAction>(dataJson)!);
        }
    }
}
