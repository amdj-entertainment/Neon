using ADE.NEON.Shared.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ADE.NEON.API.Security;
using ADE.NEON.API.Security.Models;
using ADE.NEON.BL.User;
using ADE.NEON.BL.Workspace;
using ADE.NEON.Shared.Utilities;
using Microsoft.Owin.Security;
using ADE.NEON.Shared.Models.Workspaces;
using ADE.NEON.Shared.Models.Address;
using Microsoft.AspNet.Identity;
using System.Net;

namespace ADE.NEON.API.Controllers
{
    [RoutePrefix("accounts")]
    public class AccountController : BaseController
    {
        private readonly IWorkspaceBL _workspaceBL;
        private readonly IUserBL _userBL;
        private readonly IUserProfileBL _userProfileBL;

        public AccountController(IWorkspaceBL workspaceBL, IUserBL userBL, IUserProfileBL userProfileBL)
        {
            _workspaceBL = workspaceBL;
            _userBL = userBL;
            _userProfileBL = userProfileBL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost, Route("register")]
        public async Task<IHttpActionResult> RegisterUser(UserRegisterModel registerModel)
        {
            if (registerModel == null) return BadRequest("This request is invalid");
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

                var userProfile = new UserProfileModel
                {
                    UserId = user.Id,
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName,
                    Email = registerModel.Email,
                    PhoneNumber = registerModel.PhoneNumber,
                    Address = new AddressModel
                    {
                        CountryId = registerModel.CountryId,
                        StateId = registerModel.StateId
                    }
                };

                await _userProfileBL.CreateUserProfile(userProfile);

                var workspace = new WorkspaceModel
                {
                    Name = string.Join("_", registerModel.FirstName, registerModel.LastName),
                    WorkspaceUsers = new List<WorkspaceUserModel>
                    {
                        new WorkspaceUserModel
                        {
                            UserId = user.Id
                        }
                    }
                };

                await _workspaceBL.CreateNewWorkspace(workspace);

                return registrationToken != null ? Ok() : GetErrorResult(new IdentityResult("The email address " + registerModel.Email + " is already taken. Please sign in."));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet, Route("current")]
        public async Task<IHttpActionResult> CurrentUser()
        {
            var result = await _userBL.GetCurrentUser(UserGuid);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null) return InternalServerError();
            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    throw new HttpResponseException(HttpStatusCode.NotAcceptable);
                }

                throw new HttpResponseException(HttpStatusCode.NotAcceptable);
            }
            return null;
        }
    }
}