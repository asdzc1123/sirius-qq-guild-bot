using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.PluginSupport
{
    public interface IPluginLogger
    {
        public void I(string content);
        public void D(string content);
        public void W(string content);
        public void E(string content);
    }
}
