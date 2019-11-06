using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADE.NEON.DAL.EF;
using ADE.NEON.Shared.Models.Users;
using ADE.NEON.Shared.Utilities;
using AutoMapper;

namespace ADE.NEON.DAL.Users
{
    public class UserProfileDAL : IUserProfileDAL
    {
        private readonly ICurrentTimeProvider _currentTimeProvider;
        private readonly IUniqueIdProvider _uniqueIdProvider;
        private readonly IMapper _mapper;

        public UserProfileDAL(ICurrentTimeProvider currentTimeProvider, IUniqueIdProvider uniqueIdProvider, IMapper mapper)
        {
            _currentTimeProvider = currentTimeProvider;
            _uniqueIdProvider = uniqueIdProvider;
            _mapper = mapper;
        }

        public async Task<UserProfileModel> CreateUserProfile(UnitOfWork unitOfWork, UserProfileModel userProfile)
        {
            var trackedEntity = await unitOfWork.NeonContext.UsersProfiles.FirstOrDefaultAsync(x => x.Id == userProfile.Id);
            if (trackedEntity != null) throw new EntityException("User Profile Already Exists");
            
            var profile = _mapper.Map<UsersProfile>(userProfile);

            if (profile.Address == null) throw new NullReferenceException("User must provide a country and state/province");

            profile.Address.UniqueId = _uniqueIdProvider.NewUniqueId;
            profile.Address.LastUpdate = _currentTimeProvider.LocalDateTime;
            profile.Address.CreateDate = _currentTimeProvider.LocalDateTime;

            profile.UniqueId = _uniqueIdProvider.NewUniqueId;
            profile.LastUpdate = _currentTimeProvider.LocalDateTime;
            profile.CreateDate = _currentTimeProvider.LocalDateTime;


            trackedEntity = unitOfWork.NeonContext.UsersProfiles.Add(profile);

            return _mapper.Map<UserProfileModel>(trackedEntity);
        }
    }
}
