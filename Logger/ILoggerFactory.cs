namespace Logger
{
    /// <summary>
    /// Create loggers with providers
    /// </summary>
    public interface ILoggerFactory
    {
        /// <summary>
        /// Add new provider for create logger
        /// </summary>
        /// <param name="provider"></param>
        void AddProvider(ILoggerProvider provider);

        /// <summary>
        /// Create a loggerwith specify providers
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        ILogger<TSource> CreateLogger<TSource>();
    }
}