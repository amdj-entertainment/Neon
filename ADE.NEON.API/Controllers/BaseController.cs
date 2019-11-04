using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Web;
using System.Web.Http;

namespace ADE.NEON.API.Controllers
{
    [RoutePrefix("")]
    public class BaseController : ApiController
    {
        private IOwinContext _owinContext;
        private IService _userService;

        protected virtual IOwinContext OwinContext => _owinContext ?? (_owinContext = HttpContext.Current.GetOwinContext());

        public Guid UserGuid
        {
            get
            {
                if (HttpContext.Current == null)
                    return Guid.Empty;
                var userIdString = HttpContext.Current
            }
        }
    }
}