using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.Shared.Models.Workspaces
{
    public class WorkspaceUserModel
    {
        public long Id { get; set; }
        public Guid UniqueId { get; set; }
        public Guid UserId { get; set; }
        public long WorkspaceId { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
