using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.Shared.Utilities
{
    public class CurrentTimeProvider : ICurrentTimeProvider
    {
        public DateTime LocalDateTime => DateTime.Now;
    }
}
