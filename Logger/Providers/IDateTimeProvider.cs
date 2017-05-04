using System;

namespace Logger.Providers
{
    /// <summary>
    /// Provide datetime
    /// </summary>
    public interface IDateTimeProvider
    {
        /// <summary>
        /// Get actual datetime
        /// </summary>
        DateTimeOffset Now { get; }
    }
}
