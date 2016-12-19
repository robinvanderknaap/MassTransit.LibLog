using System;
using MassTransit.Logging;

namespace MassTransit.LibLog
{
    public class LibLogLogger : ILogger
    {
        public ILog Get(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return new LibLogLog(name);
        }

        public void Shutdown()
        {
        }
    }
}