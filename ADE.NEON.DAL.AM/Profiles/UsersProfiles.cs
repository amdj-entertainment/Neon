using ADE.NEON.DAL.EF;
using ADE.NEON.Shared.Models.Users;
using AutoMapper;
using System.Linq;

namespace ADE.NEON.DAL.AM.Profiles
{
    public class UsersProfiles : Profile
    {
        public UsersProfiles()
        {
            CreateMap<NeonUser, UserModel>();
            CreateMap<UserModel, NeonUser>();

            CreateMap<NeonUser, UserLimitedModel>()
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.UsersProfile.FirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.UsersProfile.LastName));
            CreateMap<UserLimitedModel, NeonUser>();

            CreateMap<UsersProfile, UsersProfile>();
            CreateMap<UserProfileModel, UserProfileModel>();

            CreateMap<UsersProfile, UserProfileModel>();
            CreateMap<UserProfileModel, UsersProfile>();

            CreateMap<UsersProfile, UserProfileLimitedModel>();
            CreateMap<UserProfileLimitedModel, UsersProfile>();
        }
    }
}
