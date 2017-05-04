namespace Logger
{
    public interface ILoggerProvider
    {
        ILogger<TSource> CreateLogger<TSource>();
    }
}