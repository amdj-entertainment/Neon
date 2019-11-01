using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADE.NEON.Shared.Models;

namespace ADE.NEON.DAL.Events
{
    public interface IEventsDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="workspaceGuid"></param>
        /// <returns></returns>
        Task<IEnumerable<EventLimitedModel>> GetEventsForWorkspace(UnitOfWork unitOfWork, long workspaceId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="eventId"></param>
        /// <param name="workspaceId"></param>
        /// <returns></returns>
        Task<EventModel> GetEventForWorkspace(UnitOfWork unitOfWork, long eventId, long workspaceId);
    }
}
