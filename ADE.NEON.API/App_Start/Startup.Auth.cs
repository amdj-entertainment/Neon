using ADE.NEON.API.Security;
using ADE.NEON.API.Security.Models;
using ADE.NEON.API.Security.Providers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADE.NEON.API
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        public static Func<UserManager<ApplicationUser, Guid>> UserManagerFactory { get; set; }
        public static string PublicClientId { get; private set; }

        public void ConfigureAuth(IAppBuilder builder)
        {
            builder.CreatePerOwinContext(NeonSecurityDbContext.Create);
            builder.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create<NeonSecurityDbContext>);
            builder.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create<NeonSecurityDbContext>);

            const int sessionTimeout = 20;
            const int tokenTimeout = 1;
            const int failedAttemptLimit = 5;

            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new ApplicationOAuthProvider("self", failedAttemptLimit),
                AuthorizeEndpointPath = new PathString("/security/external"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(tokenTimeout),
                AllowInsecureHttp = true,
                AuthorizationCodeExpireTimeSpan = TimeSpan.FromDays(tokenTimeout),
                RefreshTokenProvider = new ApplicationRefreshTokenProvider(tokenTimeout)
            };

            builder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/security/login"),
                LogoutPath = new PathString("/security/logout"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser, Guid> (
                        TimeSpan.FromMinutes(sessionTimeout), 
                        (manager, user) => 
                            user.GenerateUserIdentityAsync(manager),
                        id => 
                            new Guid(id.GetUserId())
                    )
                },
                ExpireTimeSpan = TimeSpan.FromMinutes(sessionTimeout),
                SlidingExpiration = true,
                CookieHttpOnly = false,
                CookieSecure = CookieSecureOption.SameAsRequest,
                SystemClock = new SystemClock()
            });

            builder.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            builder.UseOAuthAuthorizationServer(OAuthOptions);
            builder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                Provider = new QueryStringOAuthBearerProvider()
            });
        }
    }
}