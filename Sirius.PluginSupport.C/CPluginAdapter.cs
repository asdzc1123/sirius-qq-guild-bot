using PInvoke;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.PluginSupport.C
{
    public class CPluginAdapter : PluginAdapterAbstract
    {
        public override IPluginFunc PluginFunc { get; }

        private readonly Kernel32.SafeLibraryHandle handle;

        public CPluginAdapter(IPluginLogger logger, string path) : base(logger, path)
        {
            handle = Kernel32.LoadLibrary(path);
            PluginFunc = CPluginFunc.CreateFormSafeLibraryHandle(handle);
            PluginFunc.OnStart();
        }


        public override void Unload(out WeakReference weakReference)
        {
            weakReference = new(handle);
            PluginFunc.OnStop();
            handle.Dispose();
        }
    }
}
