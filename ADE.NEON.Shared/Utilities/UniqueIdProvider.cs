using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.Shared.Utilities
{
    public class UniqueIdProvider : IUniqueIdProvider
    {
        public Guid NewUniqueId => Guid.NewGuid();
        public Guid NewDefaultId => Guid.Empty;
    }
}
