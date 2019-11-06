using ADE.NEON.DAL.EF;
using ADE.NEON.Shared.Models.Users;
using AutoMapper;

namespace ADE.NEON.DAL.AM.Profiles
{
    public class UsersProfiles : Profile
    {
        public UsersProfiles()
        {
            CreateMap<NeonUser, UserModel>();
            CreateMap<UserModel, NeonUser>();

            CreateMap<UsersProfile, UsersProfile>();
            CreateMap<UserProfileModel, UserProfileModel>();

            CreateMap<UsersProfile, UserProfileModel>();
            CreateMap<UserProfileModel, UsersProfile>();

            CreateMap<UsersProfile, UserProfileLimitedModel>();
            CreateMap<UserProfileLimitedModel, UsersProfile>();
        }
    }
}
