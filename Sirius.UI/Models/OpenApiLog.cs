using Sirius.CoreCSharp.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.UI.Models
{
    internal class OpenApiLog
    {
        public string Label { get; }
        public string Time { get; } = DateTime.Now.ToString();
        public string Content { get; }
        public string File { get; }
        public int Line { get; }
        public string FuncName { get; }
        public string GoError { get; }

        public OpenApiLog(string label, string content, string file, int line, string funcName, string goError)
        {
            Label = label;
            Content = content;
            File = file;
            Line = line;
            FuncName = funcName;
            GoError = goError;
        }

    }
}
