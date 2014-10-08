using MassTransit.BusConfigurators;
using MassTransit.Logging;

namespace MassTransit.LibLog
{
    public static class LibLogConfiguratorExtensions
    {
        public static void UseLibLog(this ServiceBusConfigurator configurator)
        {
            Logger.UseLogger(new LibLogLogger());
        }
    }
}
