using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.CSharpSDK
{
    public interface IBotEvent
    {
        public void OnGuildEvent(DTO.Guild data);
        public void OnGuildMemberEvent(DTO.Member data);
        public void OnChannelEvent(DTO.Channel data);
        public void OnMessageEvent(DTO.Message data);
        public void OnMessageReactionEvent(DTO.Message data);
        public void OnATMessageEvent(DTO.Message data);
        public void OnDirectMessageEvent(DTO.Message data);
        public void OnAudioEvent(DTO.AudioAction data);

    }
}
