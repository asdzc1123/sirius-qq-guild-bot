using Sirius.CSharpSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.PluginSupport.CSharp
{
    public class CSharpPluginAdapter : PluginAdapterAbstract
    {
        private AssemblyLoadContext? context;

        public CSharpPluginAdapter(IPluginLogger logger, string path) : base(logger,path)
        {

            var moduleName = path.Split('\\').Last();
            context = new AssemblyLoadContext(moduleName, true);
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read);

            Assembly assembly = context.LoadFromStream(fs);
            fs.Close();
            if (null == assembly)
            {
                throw new Exception($"加载C#插件DLL文件失败,路径:{path}");
            }

            Type? pluginAbstractClass = assembly.GetTypes().SingleOrDefault(type =>
            {
                if (null == type.BaseType)
                {
                    return false;
                }
                if (!type.BaseType.IsAbstract)
                {
                    return false;
                }
                if (type.BaseType != typeof(CSharpPluginAbstract))
                {
                    return false;
                }

                return true;
            });

            if (null == pluginAbstractClass)
            {
                throw new Exception($"获取C#插件类失败,路径:{path}");
            }

            CSharpPluginAbstract instance = (CSharpPluginAbstract)(Activator.CreateInstance(pluginAbstractClass)!);

            //反射传入OpenAPI以及Logger实例

            Type type = instance.GetType();
            FieldInfo apiField = type.GetField("api", BindingFlags.NonPublic | BindingFlags.Instance)!;
            apiField.SetValue(instance, OpenAPI.Instance);

            FieldInfo loggerField = type.GetField("logger", BindingFlags.NonPublic | BindingFlags.Instance)!;
            loggerField.SetValue(instance, Logger);



            PluginFunc = new CSharpPluginFunc(instance);
            PluginFunc.OnStart();
        }

        public override IPluginFunc PluginFunc { get; }

        public override void Unload(out WeakReference weakReference)
        {
            weakReference = new(context, trackResurrection: true);
            PluginFunc.OnStop();
            context?.Unload();
            context = null;
        }
    }
}
