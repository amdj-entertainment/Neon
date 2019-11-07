using ADE.NEON.Shared.Models.Workspaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.Shared.Models.Users
{
    public class UserLimitedModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid UserId { get; set; }
        public WorkspaceLimitedModel Workspace { get; set; }
    }
}
