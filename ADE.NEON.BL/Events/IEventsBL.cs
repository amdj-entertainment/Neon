﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADE.NEON.Shared.Models;

namespace ADE.NEON.BL.Events
{
    public interface IEventsBL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workspaceId"></param>
        /// <returns></returns>
        Task<IEnumerable<EventModel>> GetEventsForWorkspace(long workspaceId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="workspaceId"></param>
        /// <returns></returns>
        Task<EventModel> GetEventForWorkspace(long eventId, long workspaceId);
    }
}
