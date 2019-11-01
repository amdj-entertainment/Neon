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
    public class AddressesProfile : Profile
    {
        public AddressesProfile()
        {
            CreateMap<Address, AddressModel>()
                .ForMember(dest => dest.State, opts => opts.MapFrom(src => src.State.Name))
                .ForMember(dest => dest.Country, opts => opts.MapFrom(src => src.Country.Name));
            CreateMap<Country, CountryModel>();
            CreateMap<State, StateModel>();
        }
    }
}
