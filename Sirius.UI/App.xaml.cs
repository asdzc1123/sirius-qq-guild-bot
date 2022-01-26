using HandyControl.Controls;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sirius.CoreCSharp;
using Sirius.UI.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Sirius.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Dispatcher.UnhandledException += DispatcherUnhandledExceptionEventHandler;
            ServiceContainer.Configure((services) =>
            {
                services.AddSingleton<IGoLoggerService, GoLoggerService>();
                services.AddSingleton<IOpenApiLoggerService, OpenApiLoggerService>();
            });
            ServiceContainer.Find<IGoLoggerService>();
            ServiceContainer.Find<IOpenApiLoggerService>();

            base.OnStartup(e);
        }

        public void DispatcherUnhandledExceptionEventHandler(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Growl.ErrorGlobal($"未处理的异常[{e}]:{e.Exception.Message}");
        }


    }

}
