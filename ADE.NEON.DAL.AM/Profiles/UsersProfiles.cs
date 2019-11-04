using ADE.NEON.DAL.EF;
using ADE.NEON.Shared.Models.Users;
using AutoMapper;

namespace ADE.NEON.DAL.AM.Profiles
{
    public class UsersProfiles : Profile
    {
        public UsersProfiles()
        {
            CreateMap<User, UserModel>();
            CreateMap<UsersProfile, UserProfileModel>();
            CreateMap<UsersProfile, UserProfileLimitedModel>();
        }
    }
}
