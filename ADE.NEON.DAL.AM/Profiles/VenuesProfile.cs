using ADE.NEON.DAL.EF;
using ADE.NEON.Shared.Models.Venues;
using AutoMapper;

namespace ADE.NEON.DAL.AM.Profiles
{
    public class VenuesProfile : Profile
    {
        public VenuesProfile()
        {
            CreateMap<Venue, VenueModel>()
                .ForMember(dest => dest.ContactUser, opts => opts.MapFrom(src => src.UsersProfile));
        }
    }
}
