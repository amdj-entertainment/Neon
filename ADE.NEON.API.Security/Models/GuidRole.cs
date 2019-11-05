using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ADE.NEON.API.Security.Models
{
    public class GuidRole : IdentityRole<Guid, GuidUserRole>
    {
        public GuidRole()
        {
            Id = Guid.NewGuid();
        }
        public GuidRole(string name) : this() { Name = name; }
    }
}