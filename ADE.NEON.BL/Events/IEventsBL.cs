using ADE.NEON.Shared.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.BL.Events
{
    public interface IEventsBL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workspaceId"></param>
        /// <returns></returns>
        Task<IEnumerable<EventLimitedModel>> GetEventsForWorkspace(long workspaceId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="workspaceId"></param>
        /// <returns></returns>
        Task<EventModel> GetEventForWorkspace(long eventId, long workspaceId);
    }
}
