using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ADE.NEON.BL.Events;

namespace ADE.NEON.API.Controllers
{
    [RoutePrefix("events")]
    public class EventsController : ApiController
    {
        private readonly IEventsBL _eventsBL;

        public EventsController(IEventsBL eventsBL)
        {
            _eventsBL = eventsBL;
        }

        [HttpGet, Route("{workspaceId:long}/{eventId:long}")]
        public async Task<IHttpActionResult> GetEventForWorkspace(long workspaceId, long eventId)
        {
            var result = await _eventsBL.GetEventForWorkspace(eventId, workspaceId);
            return Ok(result);
        }

        [HttpGet, Route("{workspaceId:long}")]
        [Authorize]
        public async Task<IHttpActionResult> GetAllEventsForWorkspace(long workspaceId)
        {
            var results = await _eventsBL.GetEventsForWorkspace(workspaceId);
            return Ok(results);
        }
    }
}
