using System;
using System.Linq;
using System.Threading.Tasks;
using ADE.NEON.API.Security.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace ADE.NEON.API.Security
{
    public class ApplicationUserManager : UserManager<ApplicationUser, Guid>
    {
        private const int PasswordHistoryLimit = 5;
        private const int PasswordRequiredLength = 6;
        private const int TokenTimeout = 7;

        public ApplicationUserManager(IUserStore<ApplicationUser, Guid> store) : base(store)
        {
                
        }

        public ApplicationUserManager(UserStore<ApplicationUser, GuidRole, Guid, GuidUserLogin, GuidUserRole, GuidUserClaim> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create<TDbContextType>(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) where TDbContextType : ADESecurityContext
        {
            var manager = new ApplicationUserManager(new ApplicationUserStore(context.Get<TDbContextType>()));

            manager.UserValidator = new UserValidator<ApplicationUser, Guid>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = PasswordRequiredLength,
                RequireNonLetterOrDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
                RequireDigit = true
            };

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser, Guid>(dataProtectionProvider.Create("ASP.NET IDENTITY"))
                {
                    TokenLifespan = TimeSpan.FromDays(TokenTimeout)
                };

            }

            return manager;
        }

        public override async Task<IdentityResult> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword)
        {
            if (await IsPreviousPassword(userId, newPassword)) return await Task.FromResult(IdentityResult.Failed("Cannot reuse old password"));

            var result = await base.ChangePasswordAsync(userId, currentPassword, newPassword);
            if (!result.Succeeded) return result;

            if (Store is ApplicationUserStore store) await store.AddToPreviousPasswordsAsync(await FindByIdAsync(userId), PasswordHasher.HashPassword(newPassword));

            return result;
        }

        public override async Task<IdentityResult> ResetPasswordAsync(Guid userId, string token, string newPassword)
        {
            if (await IsPreviousPassword(userId, newPassword)) return await Task.FromResult(IdentityResult.Failed("Cannot reuse old password"));

            var result = await base.ResetPasswordAsync(userId, token, newPassword);
            if (!result.Succeeded) return result;

            if (Store is ApplicationUserStore store) await store.AddToPreviousPasswordsAsync(await FindByIdAsync(userId), PasswordHasher.HashPassword(newPassword));

            return result;
        }

        private async Task<bool> IsPreviousPassword(Guid userId, string newPassword)
        {
            var user = await FindByIdAsync(userId);
            return user.PreviousUserPasswords
                .OrderByDescending(x => x.CreateDate)
                .Select(x => x.PasswordHash)
                .Take(PasswordHistoryLimit)
                .Any(x => PasswordHasher.VerifyHashedPassword(x, newPassword) != PasswordVerificationResult.Failed);
        }
    }
}