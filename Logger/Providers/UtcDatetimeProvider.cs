using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Providers
{
    public class UtcDatetimeProvider : IDateTimeProvider
    {
        public DateTimeOffset Now { get; } = DateTimeOffset.UtcNow;
    }
}
