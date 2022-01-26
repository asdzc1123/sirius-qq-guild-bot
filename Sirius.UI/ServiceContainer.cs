using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.UI
{
    internal static class ServiceContainer
    {

        private static IServiceProvider? Provider { get; set; }

        static ServiceContainer()
        {

        }

        public static TService Find<TService>()
        {
            if (Provider is null)
            {
                throw new ArgumentNullException(nameof(Provider), "没有调用Configure");
            }
            return Provider.GetService<TService>()!;
        }

        public static void Configure(Action<IServiceCollection> configureDelegate)
        {
            IServiceCollection services = new ServiceCollection();
            configureDelegate(services);
            Provider = services.BuildServiceProvider();
        }
    }
}
