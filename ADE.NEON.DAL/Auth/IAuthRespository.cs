using ADE.NEON.Shared.Models.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.DAL.Auth
{
    public interface IAuthRespository : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="userRegisterModel"></param>
        /// <returns></returns>
        Task<IdentityResult> RegisterUser(UnitOfWork unitOfWork, UserRegisterModel userRegisterModel);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<IdentityUser> FindUser(string userName, string password);
    }
}
