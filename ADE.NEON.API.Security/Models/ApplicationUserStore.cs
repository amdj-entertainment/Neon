using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ADE.NEON.API.Security.Models
{
    public class ApplicationUserStore : UserStore<ApplicationUser, GuidRole, Guid, GuidUserLogin, GuidUserRole, GuidUserClaim>
    {
        public ApplicationUserStore(DbContext context) : base(context) {}

        public override async Task CreateAsync(ApplicationUser user)
        {
            await base.CreateAsync(user);
            await AddToPreviousPasswordsAsync(user, user.PasswordHash);
        }

        public Task AddToPreviousPasswordsAsync(ApplicationUser user, string password)
        {
            user.PreviousUserPasswords.Add(new PreviousPassword
            {
                UserId = user.Id,
                PasswordHash = password
            });

            return UpdateAsync(user);
        }
    }
}
