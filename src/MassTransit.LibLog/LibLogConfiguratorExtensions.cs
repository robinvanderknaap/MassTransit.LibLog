using System;
using MassTransit.Logging;

namespace MassTransit.LibLog
{
    public static class LibLogConfiguratorExtensions
    {
        public static void UseLibLog(this IBusFactoryConfigurator configurator)
        {
            if (configurator == null)
            {
                throw new ArgumentNullException(nameof(configurator));
            }

            Logger.UseLogger(new LibLogLogger());
        }
    }
}
