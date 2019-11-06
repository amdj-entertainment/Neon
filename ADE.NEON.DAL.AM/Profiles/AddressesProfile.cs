using ADE.NEON.DAL.EF;
using ADE.NEON.Shared.Models.Address;
using AutoMapper;

namespace ADE.NEON.DAL.AM.Profiles
{
    public class AddressesProfile : Profile
    {
        public AddressesProfile()
        {
            CreateMap<Address, AddressModel>()
                .ForMember(dest => dest.State, opts => opts.MapFrom(src => src.State.Name))
                .ForMember(dest => dest.Country, opts => opts.MapFrom(src => src.Country.Name));
            CreateMap<AddressModel, Address>();

            CreateMap<Country, CountryModel>();
            CreateMap<CountryModel, Country>();

            CreateMap<State, StateModel>();
            CreateMap<StateModel, State>();
        }
    }
}
