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
        public GuidUser()
        {
            Id = Guid.NewGuid();
        }

        public override Guid Id { get; set; }
        public GuidUser(string name) : this() { UserName = name; }
        public DateTime CreateDate { get; set; }
    }
}
