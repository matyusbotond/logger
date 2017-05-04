using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.AggregatedLogger
{
    public class AggregatedLogger<TSource> : ILogger<TSource>
    {
        private readonly ILogger<TSource>[] _loggers;

        public AggregatedLogger(ILogger<TSource>[] loggers)
        {
            _loggers = loggers;
        }

        public void Log(LogLevel logLevel, Exception exception, string message)
        {
            var exceptions = new List<Exception>();

            foreach (var logger in _loggers)
            {
                try
                {
                    logger.Log(logLevel, exception,message);
                }
                catch (Exception e)
                {
                    exceptions.Add(e);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }

        public void Dispose()
        {
            var exceptions = new List<Exception>();

            foreach (var logger in _loggers)
            {
                try
                {
                    logger.Dispose();
                }
                catch (Exception e)
                {
                    exceptions.Add(e);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
