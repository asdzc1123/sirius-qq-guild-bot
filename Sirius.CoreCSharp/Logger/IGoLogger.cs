using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.CoreCSharp.Logger
{
    public interface IGoLogger
    {
        public void Output(LogLevel level, string content, string file, int line, string funcName);

    }
}
