using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.PluginSupport
{
    public abstract class PluginSupportAbstract<T>
    {
        public IPluginLogger Logger { get; }
        public DirectoryInfo PluginDirectory { get; }
        public PluginSupportAbstract(IPluginLogger logger, DirectoryInfo pluginDirectory)
        {
            Logger = logger;
            PluginDirectory = pluginDirectory;
        }
        public abstract string ExtensionName { get; }

        public abstract List<T> RefreshPlugins();

        public abstract void Load(T plugin);

        public class FileComparer : IEqualityComparer<FileInfo>
        {
            public bool Equals(FileInfo? x, FileInfo? y)
            {
                if (x is null || y is null)
                {
                    return false;
                }

                int file1byte;
                int file2byte;
                FileStream fs1;
                FileStream fs2;

                if (x.FullName == y.FullName)
                {
                    return true;
                }


                fs1 = new FileStream(x.FullName, FileMode.Open);
                fs2 = new FileStream(y.FullName, FileMode.Open);

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

            public int GetHashCode([DisallowNull] FileInfo obj)
            {
                return obj.GetHashCode();
            }
        }

    }

}