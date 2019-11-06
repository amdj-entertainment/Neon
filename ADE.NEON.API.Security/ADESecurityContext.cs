using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADE.NEON.API.Security.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ADE.NEON.API.Security
{
    public abstract class ADESecurityContext : IdentityDbContext<ApplicationUser, GuidRole, Guid, GuidUserLogin, GuidUserRole, GuidUserClaim>
    {
        private readonly string _prefix;

        protected ADESecurityContext(string prefix) : base("DefaultConnection")
        {
            if (string.IsNullOrEmpty(prefix)) throw new ArgumentNullException("Prefix", "A database table name prefix is requird");
            _prefix = prefix;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var userTableName = _prefix + "Users";
            modelBuilder.Entity<GuidUser>().ToTable(userTableName).Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<ApplicationUser>().ToTable(userTableName).Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<GuidUserRole>().ToTable(_prefix + "UserRole");
            modelBuilder.Entity<GuidUserLogin>().ToTable(_prefix + "UserLogin");
            modelBuilder.Entity<GuidUserClaim>().ToTable(_prefix + "UserClaim");
            modelBuilder.Entity<GuidRole>().ToTable(_prefix + "Role");
            modelBuilder.Entity<PreviousPassword>().ToTable(_prefix + "PreviousPasswords");
        }
    }
}
