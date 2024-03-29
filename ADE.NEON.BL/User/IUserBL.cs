﻿using ADE.NEON.Shared.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.BL.User
{
    public interface IUserBL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserLimitedModel> GetCurrentUser(Guid userId);
    }
}
