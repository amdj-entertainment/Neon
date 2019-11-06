using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADE.NEON.DAL;
using ADE.NEON.DAL.Users;
using ADE.NEON.Shared.Enums;
using ADE.NEON.Shared.Models.Users;

namespace ADE.NEON.BL.User
{
    public class UserProfileBL : IUserProfileBL
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IUserProfileDAL _userProfileDAL;

        public UserProfileBL(IUnitOfWorkFactory unitOfWorkFactory, IUserProfileDAL userProfileDAL)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _userProfileDAL = userProfileDAL;
        }

        public async Task<UserProfileModel> CreateUserProfile(UserProfileModel userProfile)
        {
            var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork();

            var result = await _userProfileDAL.CreateUserProfile(unitOfWork, userProfile);

            await unitOfWork.Complete();
            return result;
        }
    }
}
