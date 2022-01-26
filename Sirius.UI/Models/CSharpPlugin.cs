
using Sirius.PluginSupport.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.UI.Models
{
    public class CSharpPlugin
    {
        public string Path { get; set; } = string.Empty;

        public CSharpPluginAdapter? Instance { get; set; }

        public bool IsLoaded { get => null != Instance; }
    }
}
