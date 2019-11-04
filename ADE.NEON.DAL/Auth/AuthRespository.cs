using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADE.NEON.DAL.EF;
using ADE.NEON.DAL.Users;
using ADE.NEON.Shared.Models.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ADE.NEON.DAL.Auth
{
    public class AuthRespository : IAuthRespository
    {
        private readonly IUserProfile _userProfile;
        private readonly AuthContext _authContext;
        private readonly UserManager<IdentityUser> _userManager;
        private long userId;

        public AuthRespository(IUserProfile userProfile)
        {
            _userProfile = userProfile;
        }

        public async Task<IdentityResult> RegisterUser(UnitOfWork unitOfWork, UserRegisterModel userRegisterModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userRegisterModel.UserName,
                PhoneNumber = userRegisterModel.PhoneNumber,
                Email = userRegisterModel.Email,
            };

            var result = await _userManager.CreateAsync(user, userRegisterModel.Password);
            long.TryParse((await _userManager.FindAsync(user.UserName, userRegisterModel.Password)).Id, out userId);

            var userProfile = new UserProfileModel
            {
                FirstName = userRegisterModel.FirstName,
                LastName = userRegisterModel.LastName,
                Email = userRegisterModel.Email,
                PhoneNumber = userRegisterModel.PhoneNumber,
                UserId = userId
            };

            await _userProfile.CreateUserProfile(unitOfWork, userProfile);

            return result;
        }

        public Task<IdentityUser> FindUser(string userName, string password)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            _authContext.Dispose();
            _userManager.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
