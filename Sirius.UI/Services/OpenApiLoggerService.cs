using Sirius.CoreCSharp.Logger;
using Sirius.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sirius.UI.Services
{
    internal interface IOpenApiLoggerService : IOpenApiLogger
    {
        public OpenApiLoggerViewModel ViewModel { get; }
    }
    internal class OpenApiLoggerService : IOpenApiLoggerService
    {
        private delegate void OpenApiLogOutputDelegate(IntPtr label, IntPtr content, IntPtr file, int line, IntPtr funcName, IntPtr goError);

        private readonly OpenApiLogOutputDelegate openApiLogOutputDelegate;

        public OpenApiLoggerViewModel ViewModel { get; } = new();

        public OpenApiLoggerService()
        {
            openApiLogOutputDelegate = OpenApiLogOutput;
            SiriusApplication.Bot.SetOpenApiLogOutputFunc(Marshal.GetFunctionPointerForDelegate(openApiLogOutputDelegate));
        }

        public static OpenApiLoggerService Instance { get; } = new();

        private void OpenApiLogOutput(IntPtr label, IntPtr content, IntPtr file, int line, IntPtr funcName, IntPtr goError)
        {
            Output(
                Marshal.PtrToStringUTF8(label)!,
                Marshal.PtrToStringUTF8(content)!,
                Marshal.PtrToStringUTF8(file)!,
                line,
                Marshal.PtrToStringUTF8(funcName)!,
                Marshal.PtrToStringUTF8(goError)!
            );
        }

        public void Output(string label, string content, string file, int line, string funcName, string goError)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                ViewModel.Add(new(label, content, file, line, funcName, goError));
            });
        }
    }
}
