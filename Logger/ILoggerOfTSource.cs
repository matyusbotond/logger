using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    /// <summary>
    /// Provide logging interface and utility functions with source of logs
    /// </summary>
    /// <typeparam name="TSource">Source of log message</typeparam>
    public interface ILogger<out TSource> : ILogger
    {
    }
}
