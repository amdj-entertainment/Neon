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
            CreateMap<UsersProfile, UserProfileModel>();
            CreateMap<UserProfileModel, UsersProfile>()
                .ForMember(dest => dest.Address, opts => opts.MapFrom(src => src.Address));
            CreateMap<UsersProfile, UserProfileLimitedModel>();
        }
    }
}
