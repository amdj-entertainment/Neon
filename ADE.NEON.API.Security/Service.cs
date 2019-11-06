using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ADE.NEON.API.Security.Models;
using Microsoft.AspNet.Identity;

namespace ADE.NEON.API.Security
{
    public class Service : IService
    {
        public ApplicationRoleManager ApplicationRoleManager { get; }
        public ApplicationUserManager UserManager { get; set; }
        public string SchemaPrefix { get; set; }

        public Service() {}

        public Service(ApplicationUserManager applicationUserManager, ApplicationRoleManager applicationRoleManager = null)
        {
            UserManager = applicationUserManager;
            ApplicationRoleManager = applicationRoleManager;
        }

        public ClaimsIdentity CreateIdentity(ApplicationUser user)
        {
            return UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ExternalBearer);
        }

        public async Task<bool> FindUser(string username, string password)
        {
            if (UserManager == null) throw new NullReferenceException();
            var user = await UserManager.FindAsync(username, password);

            return user != null;
        }

        public async Task<ApplicationUser> FindUser(Guid userId)
        {
            if (UserManager == null) throw new NullReferenceException();
            var user = await UserManager.FindByIdAsync(userId);
            return user;
        }

        public async Task<ApplicationUser> FindUser(string userName)
        {
            if (UserManager == null) throw new NullReferenceException();
            var user = await UserManager.FindByNameAsync(userName);
            return user;
        }

        public async Task<string> RegisterUser(ApplicationUser user, string password)
        {
            if (UserManager == null) throw new NullReferenceException();

            var result = await UserManager.CreateAsync(user, password);
            if (!result.Succeeded) throw new NullReferenceException();

            var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);

            return code;
        }

        public async Task<bool> ConfirmUser(Guid userId, string code)
        {
            if (UserManager == null) throw new NullReferenceException();
            if (userId == Guid.Empty) return false;
            if (string.IsNullOrWhiteSpace(code)) return false;

            var result = await UserManager.ConfirmEmailAsync(userId, code);

            return result.Succeeded;
        }

        public async Task<string> ForgotPassword(string userName)
        {
            if (UserManager == null) throw new NullReferenceException();

            var user = await UserManager.FindByNameAsync(userName);
            if (user == null) return null;
            if (!await UserManager.IsEmailConfirmedAsync(user.Id)) return null;

            var code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);

            return string.IsNullOrEmpty(code) ? null : code;
        }

        public async Task<bool> IsSystemAdministrator(Guid userId)
        {
            if (UserManager == null) throw new NullReferenceException();

            var user = await UserManager.FindByIdAsync(userId);

            return user != null && user.Claims.Any(x => x.ClaimType == ClaimTypes.Role &&  x.ClaimValue == ApplicationRoleManager.RoleNames.SystemAdministrator);
        }

        public async Task<bool> IsSystemModerator(Guid userId)
        {
            if (UserManager == null) throw new NullReferenceException();

            var user = await UserManager.FindByIdAsync(userId);

            return user != null && user.Claims.Any(x => x.ClaimType == ClaimTypes.Role && x.ClaimValue == ApplicationRoleManager.RoleNames.SystemModerator);
        }

        public async Task<bool> IsSystemSupport(Guid userId)
        {
            if (UserManager == null) throw new NullReferenceException();

            var user = await UserManager.FindByIdAsync(userId);

            return user != null && user.Claims.Any(x => x.ClaimType == ClaimTypes.Role && x.ClaimValue == ApplicationRoleManager.RoleNames.SystemSupport);
        }

        public async Task<bool> IsSystemEditor(Guid userId)
        {
            if (UserManager == null) throw new NullReferenceException();

            var user = await UserManager.FindByIdAsync(userId);

            return user != null && user.Claims.Any(x => x.ClaimType == ClaimTypes.Role && x.ClaimValue == ApplicationRoleManager.RoleNames.SystemEditor);
        }

        public async Task<bool> ToggleSystemAdministrator(Guid userId)
        {
            if (UserManager == null) throw new NullReferenceException();

            var user = await UserManager.FindByIdAsync(userId);
            if (user == null) return false;

            IdentityResult result;
            if (await IsSystemAdministrator(userId))
            {
                await UserManager.RemoveFromRoleAsync(userId, ApplicationRoleManager.RoleNames.SystemAdministrator);
                result = await UserManager.RemoveClaimAsync(userId, new Claim(ClaimTypes.Role, ApplicationRoleManager.RoleNames.SystemAdministrator));
            }
            else
            {
                await UserManager.AddToRoleAsync(userId, ApplicationRoleManager.RoleNames.SystemAdministrator);
                result = await  UserManager.AddClaimAsync(userId, new Claim(ClaimTypes.Role, ApplicationRoleManager.RoleNames.SystemAdministrator));
            }

            return result.Succeeded;
        }
        public async Task<bool> ToggleSystemModerator(Guid userId)
        {
            if (UserManager == null) throw new NullReferenceException();

            var user = await UserManager.FindByIdAsync(userId);
            if (user == null) return false;

            IdentityResult result;
            if (await IsSystemModerator(userId))
            {
                await UserManager.RemoveFromRoleAsync(userId, ApplicationRoleManager.RoleNames.SystemModerator);
                result = await UserManager.RemoveClaimAsync(userId, new Claim(ClaimTypes.Role, ApplicationRoleManager.RoleNames.SystemModerator));
            }
            else
            {
                await UserManager.AddToRoleAsync(userId, ApplicationRoleManager.RoleNames.SystemModerator);
                result = await UserManager.AddClaimAsync(userId, new Claim(ClaimTypes.Role, ApplicationRoleManager.RoleNames.SystemModerator));
            }

            return result.Succeeded;
        }
        public async Task<bool> ToggleSystemSupport(Guid userId)
        {
            if (UserManager == null) throw new NullReferenceException();

            var user = await UserManager.FindByIdAsync(userId);
            if (user == null) return false;

            IdentityResult result;
            if (await IsSystemSupport(userId))
            {
                await UserManager.RemoveFromRoleAsync(userId, ApplicationRoleManager.RoleNames.SystemSupport);
                result = await UserManager.RemoveClaimAsync(userId, new Claim(ClaimTypes.Role, ApplicationRoleManager.RoleNames.SystemSupport));
            }
            else
            {
                await UserManager.AddToRoleAsync(userId, ApplicationRoleManager.RoleNames.SystemSupport);
                result = await UserManager.AddClaimAsync(userId, new Claim(ClaimTypes.Role, ApplicationRoleManager.RoleNames.SystemSupport));
            }

            return result.Succeeded;
        }
        public async Task<bool> ToggleSystemEditor(Guid userId)
        {
            if (UserManager == null) throw new NullReferenceException();

            var user = await UserManager.FindByIdAsync(userId);
            if (user == null) return false;

            IdentityResult result;
            if (await IsSystemEditor(userId))
            {
                await UserManager.RemoveFromRoleAsync(userId, ApplicationRoleManager.RoleNames.SystemEditor);
                result = await UserManager.RemoveClaimAsync(userId, new Claim(ClaimTypes.Role, ApplicationRoleManager.RoleNames.SystemEditor));
            }
            else
            {
                await UserManager.AddToRoleAsync(userId, ApplicationRoleManager.RoleNames.SystemEditor);
                result = await UserManager.AddClaimAsync(userId, new Claim(ClaimTypes.Role, ApplicationRoleManager.RoleNames.SystemEditor));
            }

            return result.Succeeded;
        }

    }
}
