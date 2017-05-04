namespace Logger
{
    /// <summary>
    /// Provide some logger
    /// </summary>
    public interface ILoggerProvider
    {
        /// <summary>
        /// Create some logger
        /// </summary>
        /// <typeparam name="TSource">Source of logs</typeparam>
        /// <returns>Some logger</returns>
        ILogger<TSource> CreateLogger<TSource>();
    }
}