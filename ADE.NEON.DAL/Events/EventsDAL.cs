using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ADE.NEON.Shared.Models.Events;
using AutoMapper;

namespace ADE.NEON.DAL.Events
{
    public class EventsDAL : IEventsDAL
    {
        private IMapper _mapper;

        public EventsDAL(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventLimitedModel>> GetEventsForWorkspace(UnitOfWork unitOfWork, long workspaceId)
        {
            try
            {
                var trackedEntity = unitOfWork.NeonContext.Events.Where(x => x.WorkspaceId == workspaceId);
                return await _mapper.ProjectTo<EventLimitedModel>(trackedEntity).ToListAsync();

            }
            catch (Exception)
            {
                // TODO: LOG ERRORS
                throw;
            }
        }

        public async Task<EventModel> GetEventForWorkspace(UnitOfWork unitOfWork, long eventId, long workspaceId)
        {
            try
            {
                var trackedEntity = await unitOfWork.NeonContext.Events
                    .Where(x => x.Id == eventId && x.WorkspaceId == workspaceId).FirstOrDefaultAsync();

                return _mapper.Map<EventModel>(trackedEntity);
            }
            catch (Exception)
            {
                // TODO: LOG ERRORS
                throw;
            }
        }
    }
}
