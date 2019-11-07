using ADE.NEON.DAL;
using ADE.NEON.DAL.Users;
using ADE.NEON.Shared.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.BL.User
{
    public class UserBL : IUserBL
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IUserDAL _userDAL;

        public UserBL(IUnitOfWorkFactory unitOfWorkFactory, IUserDAL userDAL)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _userDAL = userDAL;
        }

        public async Task<UserLimitedModel> GetCurrentUser(Guid userId)
        {
            var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork();

            var result = await _userDAL.GetCurrentUser(unitOfWork, userId);

            return result;
        }
    }
}
