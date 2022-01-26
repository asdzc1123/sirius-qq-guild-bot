using Sirius.CoreCSharp;
using Sirius.CoreCSharp.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.UI.Models
{
    public class GoLog
    {
        public LogLevel Level { get; }
        public string Time { get; } = DateTime.Now.ToString();
        public string Content { get; }
        public string File { get; }
        public int Line { get; }

        public string FuncName { get; }
        public GoLog(LogLevel level, string content, string file, int line,string funcName)
        {
            Level = level;
            Content = content;
            File = file;
            Line = line;
            FuncName = funcName;
        }

    }
}
