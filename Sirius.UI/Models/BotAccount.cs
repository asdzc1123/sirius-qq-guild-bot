using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.UI.Models
{
    internal class BotAccount
    {
        public ulong BotId { get; set; }

        public string BotToken { get; set; } = string.Empty;
    }
}
