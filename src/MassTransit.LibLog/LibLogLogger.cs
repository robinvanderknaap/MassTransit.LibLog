using MassTransit.Logging;

namespace MassTransit.LibLog
{
    public class LibLogLogger : ILogger
    {
        public ILog Get(string name)
        {
            return new LibLogLog(name);
        }
    }
}