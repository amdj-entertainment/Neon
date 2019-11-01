using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ADE.NEON.Shared.Models;

namespace ADE.NEON.API.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : BaseController
    {
        public UsersController()
        {
            
        }

        [HttpGet, Route("current")]
        public async Task<IHttpActionResult> GetCurrentUser()
        {
            return await Task.Run(() => Ok());
        }
    }
}