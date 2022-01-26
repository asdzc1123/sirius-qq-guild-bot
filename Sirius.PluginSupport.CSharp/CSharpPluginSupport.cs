using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.PluginSupport.CSharp
{
    public class CSharpPluginSupport : PluginSupportAbstract<CSharpPlugin>
    {
        public CSharpPluginSupport(IPluginLogger logger, DirectoryInfo pluginDirectory) : base(logger, pluginDirectory)
        {

        }

        public override string ExtensionName => throw new NotImplementedException();

        public override void Load(CSharpPlugin plugin)
        {
            plugin.Instance = new CSharpPluginAdapter(Logger, plugin.Path);
        }

        public override List<CSharpPlugin> RefreshPlugins()
        {
            List<CSharpPlugin> plugins = new();
            if (PluginDirectory.Exists)
            {
                HashSet<FileInfo> files = new(PluginDirectory.GetFiles(), new FileComparer());
                foreach (FileInfo file in files)
                {
                    if (ExtensionName.Equals(file.Extension, StringComparison.OrdinalIgnoreCase))
                    {
                        plugins.Add(new()
                        {
                            Path = file.FullName,
                        });
                    }
                }
            }
            else
            {
                PluginDirectory.Create();
            }
            return plugins;
        }
    }
}
