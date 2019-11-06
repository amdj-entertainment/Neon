using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADE.NEON.DAL;
using ADE.NEON.DAL.Events;
using ADE.NEON.Shared.Enums;
using ADE.NEON.Shared.Models.Events;

namespace ADE.NEON.BL.Events
{
    public class EventsBL : IEventsBL
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IEventsDAL _eventsDAL;

        public EventsBL(IUnitOfWorkFactory unitOfWorkFactory, IEventsDAL eventsDAL)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _eventsDAL = eventsDAL;
        }
        public async Task<IEnumerable<EventLimitedModel>> GetEventsForWorkspace(long workspaceId)
        {
            var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork();
            var results = await _eventsDAL.GetEventsForWorkspace(unitOfWork, workspaceId);
            return results;
        }

        public async Task<EventModel> GetEventForWorkspace(long eventId, long workspaceId)
        {
            var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork();

            var result = await _eventsDAL.GetEventForWorkspace(unitOfWork, eventId, workspaceId);
            return result;
        }
    }
}
