using ADE.NEON.Shared.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ADE.NEON.API.Controllers
{
    [RoutePrefix("accounts")]
    public class AccountController : BaseController
    {
        public AccountController()
        {

        }

        //[AllowAnonymous]
        //[HttpGet, Route("register")]
        //public async Task<IHttpActionResult> RegisterUser(UserRegisterModel registerModel)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);

        //}
    }
}