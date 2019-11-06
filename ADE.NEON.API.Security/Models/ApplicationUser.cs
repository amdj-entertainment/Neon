using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace ADE.NEON.API.Security.Models
{
    public class ApplicationUser : GuidUser
    {
        public ApplicationUser() : base()
        {
            CreateDate = DateTime.Now;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, Guid> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }

        public virtual IList<PreviousPassword> PreviousUserPasswords { get; set; } = new List<PreviousPassword>();
    }
}