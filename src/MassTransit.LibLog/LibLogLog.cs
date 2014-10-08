using System;
using MassTransit.LibLog.Logging;
using MassTransit.Logging;
using ILog = MassTransit.Logging.ILog;
using LogLevel = MassTransit.Logging.LogLevel;

namespace MassTransit.LibLog
{
    public class LibLogLog : ILog
    {
        // LibLog logger
        private readonly Logging.ILog _logger;

        public LibLogLog(string name)
        {
            // Get lib log logger
            _logger = LogProvider.GetLogger(name);
        }

        public void Log(LogLevel level, object obj)
        {
            // Map masstransit loglevel to liblog loglevel
            var logLevel = MapLogLevel(level);

            // Don't log anything if loglevel is not specified
            if (logLevel == null) return;

            _logger.Log(logLevel.Value, () => FormatObject(obj));
        }

        public void Log(LogLevel level, object obj, Exception exception)
        {
            // If exception is null, use log method without exception
            if (exception == null)
            {
                Log(level, obj);
                return;
            }

            // Map masstransit loglevel to liblog loglevel
            var logLevel = MapLogLevel(level);

            // Don't log anything if loglevel is not specified
            if (logLevel == null) return;

            _logger.Log(logLevel.Value, () => FormatObject(obj), exception);
        }

        public void Log(LogLevel level, LogOutputProvider messageProvider)
        {
            Log(level, messageProvider());
        }

        public void LogFormat(LogLevel level, IFormatProvider formatProvider, string format, params object[] args)
        {
            Log(level, string.Format(formatProvider, format, args));
        }

        public void LogFormat(LogLevel level, string format, params object[] args)
        {
            Log(level, string.Format(format, args));
        }

        public void Debug(object obj)
        {
            Log(LogLevel.Debug, obj);
        }

        public void Debug(object obj, Exception exception)
        {
            Log(LogLevel.Debug, obj, exception);
        }

        public void Debug(LogOutputProvider messageProvider)
        {
            Log(LogLevel.Debug, messageProvider);
        }

        public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            LogFormat(LogLevel.Debug, formatProvider, format, args);
        }

        public void DebugFormat(string format, params object[] args)
        {
            LogFormat(LogLevel.Debug, format, args);
        }

        public void Info(object obj)
        {
            Log(LogLevel.Info, obj);
        }

        public void Info(object obj, Exception exception)
        {
            Log(LogLevel.Info, obj, exception);
        }

        public void Info(LogOutputProvider messageProvider)
        {
            Log(LogLevel.Info, messageProvider);
        }

        public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            LogFormat(LogLevel.Info, formatProvider, format, args);
        }

        public void InfoFormat(string format, params object[] args)
        {
            LogFormat(LogLevel.Info, format, args);
        }

        public void Warn(object obj)
        {
            Log(LogLevel.Warn, obj);
        }

        public void Warn(object obj, Exception exception)
        {
            Log(LogLevel.Warn, obj, exception);
        }

        public void Warn(LogOutputProvider messageProvider)
        {
            Log(LogLevel.Warn, messageProvider);
        }

        public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            LogFormat(LogLevel.Warn, formatProvider, format, args);
        }

        public void WarnFormat(string format, params object[] args)
        {
            LogFormat(LogLevel.Warn, format, args);
        }

        public void Error(object obj)
        {
            Log(LogLevel.Error, obj);
        }

        public void Error(object obj, Exception exception)
        {
            Log(LogLevel.Error, obj, exception);
        }

        public void Error(LogOutputProvider messageProvider)
        {
            Log(LogLevel.Error, messageProvider);
        }

        public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            LogFormat(LogLevel.Error, formatProvider, format, args);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            LogFormat(LogLevel.Error, format, args);
        }

        public void Fatal(object obj)
        {
            Log(LogLevel.Fatal, obj);
        }

        public void Fatal(object obj, Exception exception)
        {
            Log(LogLevel.Fatal, obj, exception);
        }

        public void Fatal(LogOutputProvider messageProvider)
        {
            Log(LogLevel.Fatal, messageProvider);
        }

        public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            LogFormat(LogLevel.Fatal, formatProvider, format, args);
        }

        public void FatalFormat(string format, params object[] args)
        {
            LogFormat(LogLevel.Fatal, format, args);
        }

        public bool IsDebugEnabled
        {
            get { return _logger.IsDebugEnabled(); }
        }

        public bool IsInfoEnabled
        {
            get { return _logger.IsInfoEnabled(); }
        }

        public bool IsWarnEnabled
        {
            get { return _logger.IsWarnEnabled(); }
        }

        public bool IsErrorEnabled
        {
            get { return _logger.IsErrorEnabled(); }
        }

        public bool IsFatalEnabled
        {
            get { return _logger.IsFatalEnabled(); }
        }


        private static string FormatObject(object obj)
        {
            return obj == null ? "" : obj.ToString();
        }

        private static Logging.LogLevel? MapLogLevel(LogLevel loglevel)
        {
            if (loglevel == LogLevel.Fatal)
                return Logging.LogLevel.Fatal;
            if (loglevel == LogLevel.Error)
                return Logging.LogLevel.Error;
            if (loglevel == LogLevel.Warn)
                return Logging.LogLevel.Warn;
            if (loglevel == LogLevel.Info)
                return Logging.LogLevel.Info;
            if (loglevel == LogLevel.Debug)
                return Logging.LogLevel.Debug;
            if (loglevel == LogLevel.All)
                return Logging.LogLevel.Trace;
            
            // Masstransit supports LogLevel None, which is not supported by LibLog
            // We return null, so the log methods can check for null and decide not to log anything
            return null;
        }
    }
}