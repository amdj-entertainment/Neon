using ADE.NEON.Shared.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ADE.NEON.API.Security;
using ADE.NEON.API.Security.Models;

namespace ADE.NEON.API.Controllers
{
    [RoutePrefix("accounts")]
    public class AccountController : BaseController
    {
        public AccountController()
        {

        }

        [AllowAnonymous]
        [HttpPost, Route("register")]
        public async Task<IHttpActionResult> RegisterUser(UserRegisterModel registerModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = new ApplicationUser
            {
                UserName = registerModel.UserName,
                Email = registerModel.Email,
                PhoneNumber = registerModel.PhoneNumber
            };

            try
            {
                var registrationToken = await UserManagerService.RegisterUser(user, registerModel.Password);

                return null;
            }
            catch (Exception)
            {
                return BadRequest("Error Creating User");
            }
        }
    }
}