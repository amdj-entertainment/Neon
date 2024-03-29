﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADE.NEON.DAL;
using ADE.NEON.DAL.Workspace;
using ADE.NEON.Shared.Enums;
using ADE.NEON.Shared.Models.Workspaces;

namespace ADE.NEON.BL.Workspace
{
    public class WorkspaceBL : IWorkspaceBL
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IWorkspaceDAL _workspaceDAL;

        public WorkspaceBL(IUnitOfWorkFactory unitOfWorkFactory, IWorkspaceDAL workspaceDAL)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _workspaceDAL = workspaceDAL;
        }

        public async Task<WorkspaceModel> GetWorkspaceById(long workspaceId)
        {
            var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork();

            var result = await _workspaceDAL.GetWorkspaceById(unitOfWork, workspaceId);
            return result;
        }

        public Task<WorkspaceModel> GetWorkspaceByUniqueId(Guid workspaceGuid)
        {
            throw new NotImplementedException();
        }

        public async Task<WorkspaceModel> CreateNewWorkspace(WorkspaceModel workspace)
        {
            var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork();

            var result = await _workspaceDAL.CreateNewWorkspace(unitOfWork, workspace);

            await unitOfWork.Complete();
            return result;
        }

        public Task<bool> UpdateWorkspace(WorkspaceModel workspace)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteWorkspaceById(long workspaceId)
        {
            throw new NotImplementedException();
        }
    }
}
