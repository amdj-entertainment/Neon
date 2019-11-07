using ADE.NEON.Shared.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.DAL.Users
{
    public interface IUserDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserLimitedModel> GetCurrentUser(UnitOfWork unitOfWork, Guid userId);
    }
}
