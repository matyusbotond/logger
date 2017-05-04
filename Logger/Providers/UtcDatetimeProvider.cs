using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Providers
{
    /// <summary>
    /// Provide UTC datetime
    /// </summary>
    public class UtcDatetimeProvider : IDateTimeProvider
    {
        public DateTimeOffset Now { get; } = DateTimeOffset.UtcNow;
    }
}
