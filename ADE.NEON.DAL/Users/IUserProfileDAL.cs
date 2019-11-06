using ADE.NEON.Shared.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.DAL.Users
{
    public interface IUserProfileDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        Task<UserProfileModel> CreateUserProfile(UnitOfWork unitOfWork, UserProfileModel userProfile);
    }
}
