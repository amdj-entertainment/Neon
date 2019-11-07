using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.Shared.Models.Workspaces
{
    public class WorkspaceLimitedModel
    {
        public long Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
    }
}
