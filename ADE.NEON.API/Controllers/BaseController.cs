using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Web;
using System.Web.Http;
using ADE.NEON.API.Security;

namespace ADE.NEON.API.Controllers
{
    [RoutePrefix("")]
    public class BaseController : ApiController
    {
        private IOwinContext _owinContext;
        private IService _userManagerService;

        protected virtual IOwinContext OwinContext => _owinContext ?? (_owinContext = HttpContext.Current.GetOwinContext());

        public Guid UserGuid
        {
            get
            {
                if (HttpContext.Current == null) return Guid.Empty;
                var userIdString = HttpContext.Current.User.Identity.GetUserId();
                return Guid.TryParse(userIdString, out var userId) ? userId : Guid.Empty;
            }
        }

        protected virtual IService UserManagerService => _userManagerService ?? (_userManagerService = new Service(OwinContext.GetUserManager<ApplicationUserManager>()));
    }
}