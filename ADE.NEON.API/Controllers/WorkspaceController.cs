using ADE.NEON.BL.Workspace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ADE.NEON.API.Controllers
{
    [RoutePrefix("workspaces")]
    public class WorkspaceController : BaseController
    {
        private readonly IWorkspaceBL _workspaceBL;

        public WorkspaceController(IWorkspaceBL workspaceBL)
        {
            _workspaceBL = workspaceBL;
        }

        [HttpGet, Route("{workspaceId:long}")]
        public async Task<IHttpActionResult> GetWorkspaceById(long workspaceId)
        {
            var result = await _workspaceBL.GetWorkspaceById(workspaceId);
            return Ok(result);
        }
    }
}