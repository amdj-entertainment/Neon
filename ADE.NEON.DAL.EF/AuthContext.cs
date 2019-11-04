using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.DAL.EF
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext() : base("NeonContext") { }
    }
}
