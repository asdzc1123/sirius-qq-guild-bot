using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.CoreCSharp.Logger
{
    public interface IOpenApiLogger
    {
        public void Output(string label, string content, string file, int line, string funcName, string goError);
    }
}
