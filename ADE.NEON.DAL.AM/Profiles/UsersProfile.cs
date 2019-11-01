using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADE.NEON.DAL.EF;
using ADE.NEON.Shared.Models;
using AutoMapper;

namespace ADE.NEON.DAL.AM.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<EF.UsersProfile, UserProfileModel>();
            CreateMap<EF.UsersProfile, UserProfileLimitedModel>();
        }
    }
}
