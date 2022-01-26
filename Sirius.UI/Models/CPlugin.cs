using Sirius.PluginSupport.C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.UI.Models
{
    internal class CPlugin
    {
        public string Path { get; set; } = string.Empty;

        public CPluginAdapter? Instance { get; set; }

        public bool IsLoaded { get => null != Instance; }
    }
}
