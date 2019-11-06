using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADE.NEON.DAL.EF;
using ADE.NEON.Shared.Models.Users;
using AutoMapper;

namespace ADE.NEON.DAL.Users
{
    public class UserProfileDAL : IUserProfileDAL
    {
        private IMapper _mapper;

        public UserProfileDAL(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<UserProfileModel> CreateUserProfile(UnitOfWork unitOfWork, UserProfileModel userProfile)
        {
            try
            {
                var profile = _mapper.Map<UsersProfile>(userProfile);
                var trackedEntity = unitOfWork.NeonContext.UsersProfiles.Add(profile);

                await unitOfWork.NeonContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: 
                throw;
            }
            return null;
        }
    }
}
