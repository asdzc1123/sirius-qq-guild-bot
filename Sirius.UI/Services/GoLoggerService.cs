using Sirius.CoreCSharp;
using Sirius.CoreCSharp.Logger;
using Sirius.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sirius.UI.Services
{
    internal interface IGoLoggerService : IGoLogger
    {
        public GoLoggerViewModel ViewModel { get; }
    }
    internal class GoLoggerService : IGoLoggerService
    {
        private delegate void GoLogOutputDelegate(IntPtr level, IntPtr content, IntPtr file, int line, IntPtr funcName);

        private readonly GoLogOutputDelegate goLogOutputDelegate;

        public GoLoggerViewModel ViewModel { get; } = new();

        public GoLoggerService()
        {
            goLogOutputDelegate = GoLogOutput;
            SiriusApplication.Bot.SetGoLogOutputFuncAddress(Marshal.GetFunctionPointerForDelegate(goLogOutputDelegate));
        }

        private void GoLogOutput(IntPtr level, IntPtr content, IntPtr file, int line, IntPtr funcName)
        {
            Output(
                Enum.Parse<LogLevel>(Marshal.PtrToStringUTF8(level)!),
                Marshal.PtrToStringUTF8(content)!,
                Marshal.PtrToStringUTF8(file)!,
                line,
                Marshal.PtrToStringUTF8(funcName)!
                );
        }


        public void Output(LogLevel level, string content, string file, int line, string funcName)
        {
            Application.Current.Dispatcher.BeginInvoke(() =>
            {
                ViewModel.Add(new(level, content, file, line, funcName));
            });
        }

    }
}
