using ADE.NEON.Shared.Models.Workspaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.DAL.Workspace
{
    public interface IWorkspaceDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="workspaceId"></param>
        /// <returns></returns>
        Task<WorkspaceModel> GetWorkspaceById(UnitOfWork unitOfWork, long workspaceId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="workspaceGuid"></param>
        /// <returns></returns>
        Task<WorkspaceModel> GetWorkspaceByUniqueId(UnitOfWork unitOfWork, Guid workspaceGuid);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="workspace"></param>
        /// <returns></returns>
        Task<WorkspaceModel> CreateNewWorkspace(UnitOfWork unitOfWork, WorkspaceModel workspace);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="workspace"></param>
        /// <returns></returns>
        Task<bool> UpdateWorkspace(UnitOfWork unitOfWork, WorkspaceModel workspace);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="workspaceId"></param>
        /// <returns></returns>
        Task<bool> DeleteWorkspaceById(UnitOfWork unitOfWork, long workspaceId);
    }
}
