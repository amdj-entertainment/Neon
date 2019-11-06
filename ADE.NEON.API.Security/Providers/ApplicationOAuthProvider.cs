using ADE.NEON.API.Security.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.API.Security.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicCLientId;
        private readonly Func<UserManager<ApplicationUser, Guid>> _userManagerFactory;
        private readonly int _maximumFailedAttempts;

        public ApplicationOAuthProvider(string publicClientId, Func<UserManager<ApplicationUser, Guid>> userManagerFactory)
        {
            _publicCLientId = publicClientId ?? throw new ArgumentNullException(nameof(publicClientId));
            _userManagerFactory = userManagerFactory ?? throw new ArgumentNullException(nameof(userManagerFactory));
        }

        public ApplicationOAuthProvider(string publicClientId, int failedLoginAttempts)
        {
            _publicCLientId = publicClientId ?? throw new ArgumentNullException(nameof(publicClientId));
            _maximumFailedAttempts = failedLoginAttempts;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            userManager.MaxFailedAccessAttemptsBeforeLockout = _maximumFailedAttempts + 1;
            var user = await userManager.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                user = await userManager.FindByNameAsync(context.UserName);
                if (user != null && !await userManager.IsLockedOutAsync(user.Id))
                {
                    await userManager.SetLockoutEnabledAsync(user.Id, true);
                    await userManager.AccessFailedAsync(user.Id);
                    var failedCount = await userManager.GetAccessFailedCountAsync(user.Id);
                    if (failedCount >= _maximumFailedAttempts) await userManager.SetLockoutEndDateAsync(user.Id, DateTimeOffset.MaxValue);
                }

                context.SetError("invalid_grant", "The username or password is incorrect.");
                return;
            }

            if (await userManager.IsLockedOutAsync(user.Id))
            {
                context.SetError("user_lockout", "The user si locked out.");
                return;
            }

            var oAuthIdentity = await user.GenerateUserIdentityAsync(userManager);
            var properties = CreateProperties(user.UserName);
            var ticket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(oAuthIdentity);

            await userManager.ResetAccessFailedCountAsync(user.Id);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicCLientId)
            {
                var expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}
