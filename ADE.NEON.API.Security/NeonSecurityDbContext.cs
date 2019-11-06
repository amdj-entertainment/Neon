using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.API.Security
{
    public class NeonSecurityDbContext : ADESecurityContext
    {
        public NeonSecurityDbContext() : base("Neon") {}
        public static NeonSecurityDbContext Create() => new NeonSecurityDbContext();
    }
}
