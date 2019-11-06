using ADE.NEON.DAL.EF;
using ADE.NEON.Shared.Models.Events;
using AutoMapper;

namespace ADE.NEON.DAL.AM.Profiles
{
    internal class EventsProfile : Profile
    {
        public EventsProfile()
        {
            CreateMap<Event, EventModel>();
            CreateMap<EventModel, Event>();

            CreateMap<Event, EventLimitedModel>();
            CreateMap<EventLimitedModel, Event>();
        }
    }
}
