using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.PluginSupport
{
    public abstract class PluginAdapterAbstract
    {
        public IPluginLogger Logger { get; }
        public string Path { get; }
        public PluginAdapterAbstract(IPluginLogger logger, string path)
        {
            Logger = logger;
            Path = path;
        }
        public abstract IPluginFunc PluginFunc { get; }
        public abstract void Unload(out WeakReference weakReference);
    }

    public class PluginAdapterComparer : IEqualityComparer<PluginAdapterAbstract>
    {
        public bool Equals(PluginAdapterAbstract? x, PluginAdapterAbstract? y)
        {
            if (x is null || y is null)
            {
                return false;
            }
            return FileCompare(x.Path, y.Path);
        }

        public int GetHashCode([DisallowNull] PluginAdapterAbstract obj)
        {
            return obj.Path.GetHashCode();
        }

        private static bool FileCompare(string path1, string path2)
        {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            if (path1 == path2)
            {
                return true;
            }


            fs1 = new FileStream(path1, FileMode.Open);
            fs2 = new FileStream(path2, FileMode.Open);

            if (fs1.Length != fs2.Length)
            {
                fs1.Close();
                fs2.Close();

                return false;
            }

            do
            {
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            fs1.Close();
            fs2.Close();

            return ((file1byte - file2byte) == 0);
        }
    }
}
