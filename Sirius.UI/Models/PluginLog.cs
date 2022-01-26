using Sirius.CoreCSharp.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.UI.Models
{
    internal class PluginLog
    {
        public LogLevel Level { get; }
        public string Time { get; } = DateTime.Now.ToString();
        public string Content { get; }
        public string File { get; }
        public int Line { get; }

        private PluginLog(LogLevel level, string content, string file, int line)
        {
            Level = level;
            Content = content;
            File = file;
            Line = line;
        }
        public static PluginLog New(LogLevel level, string content, string file, int line)
        {
            return new(level, content, file, line);
        }
    }
}
