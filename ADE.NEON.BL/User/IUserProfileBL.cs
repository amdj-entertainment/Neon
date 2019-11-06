using ADE.NEON.Shared.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.BL.User
{
    public interface IUserProfileBL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        Task<UserProfileModel> CreateUserProfile(UserProfileModel userProfile);
    }
}
