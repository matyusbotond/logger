using System;

namespace Logger.Providers
{
    public interface IDateTimeProvider
    {
        DateTimeOffset Now { get; }
    }
}
