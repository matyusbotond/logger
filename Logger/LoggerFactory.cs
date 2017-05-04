using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.AggregatedLogger;

namespace Logger
{
    /// <summary>
    /// Singleton logger factory
    /// </summary>
    public class LoggerFactory : ILoggerFactory
    {
        public static LoggerFactory Instance { get; } = new LoggerFactory();

        protected LoggerFactory()
        {
        }

        protected Dictionary<Type, ILoggerProvider> _providers = new Dictionary<Type, ILoggerProvider>();


        public void AddProvider(ILoggerProvider provider)
        {
            var type = provider.GetType();

            if (!_providers.ContainsKey(type))
            {
                _providers.Add(type, provider);
            }

        }

        public ILogger<TSource> CreateLogger<TSource>()
        {
            return new AggregatedLogger<TSource>(_providers.Values.Select(p => p.CreateLogger<TSource>()).ToArray());
        }
    }
}
