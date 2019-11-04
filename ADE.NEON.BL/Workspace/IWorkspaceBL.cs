using ADE.NEON.Shared.Models.Workspaces;
using System;
using System.Threading.Tasks;

namespace ADE.NEON.BL.Workspace
{
    public interface IWorkspaceBL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workspaceId"></param>
        /// <returns></returns>
        Task<WorkspaceModel> GetWorkspaceById(long workspaceId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workspaceGuid"></param>
        /// <returns></returns>
        Task<WorkspaceModel> GetWorkspaceByUniqueId(Guid workspaceGuid);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workspace"></param>
        /// <returns></returns>
        Task<WorkspaceModel> CreateNewWorkspace(WorkspaceModel workspace);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workspace"></param>
        /// <returns></returns>
        Task<bool> UpdateWorkspace(WorkspaceModel workspace);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workspaceId"></param>
        /// <returns></returns>
        Task<bool> DeleteWorkspaceById(long workspaceId);
    }
}
