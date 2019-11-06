using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ADE.NEON.API.Security.Models
{
    public class GuidUser : IdentityUser<Guid, GuidUserLogin, GuidUserRole, GuidUserClaim>
    {
        public GuidUser() {}

        public override Guid Id { get; set; } = Guid.NewGuid();
        public GuidUser(string name) : this()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            UserName = name;
        }

        public DateTime CreateDate { get; set; }
    }
}
