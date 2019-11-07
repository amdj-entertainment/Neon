using ADE.NEON.API.Security.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ADE.NEON.API.Security.Attributes
{
    public sealed class AuthorizeAdministrator : AuthorizeAttribute
    {
        public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var currentUser = HttpContext.Current.User;
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            if (!currentUser.Identity.IsAuthenticated)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return Task.FromResult<object>(null);
            }

            var userId = Guid.Parse(currentUser.Identity.GetUserId());
            var applicationUser = userManager.FindById(userId);

            if (!applicationUser.Claims.Any(x => x.ClaimType == ClaimTypes.Role && x.ClaimValue == ApplicationRoleManager.RoleNames.SystemAdministrator))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return Task.FromResult<object>(null);
            }

            return Task.FromResult<object>(null);
        }
    }
}
