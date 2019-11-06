using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.Shared.Utilities
{
    public interface IUniqueIdProvider
    {
        Guid NewUniqueId { get; }
        Guid NewDefaultId { get; }
    }
}
