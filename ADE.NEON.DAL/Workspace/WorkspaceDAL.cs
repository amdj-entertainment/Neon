using ADE.NEON.Shared.Models.Workspaces;
using ADE.NEON.Shared.Utilities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.DAL.Workspace
{
    public class WorkspaceDAL : IWorkspaceDAL
    {
        private readonly ICurrentTimeProvider _currentTimeProvider;
        private readonly IMapper _mapper;

        public WorkspaceDAL(ICurrentTimeProvider currentTimeProvider, IMapper mapper)
        {
            _currentTimeProvider = currentTimeProvider;
            _mapper = mapper;
        }

        public async Task<WorkspaceModel> GetWorkspaceById(UnitOfWork unitOfWork, long workspaceId)
        {
            try
            {
                var trackedEntity = await unitOfWork.NeonContext.Workspaces.Where(x => x.Id == workspaceId).FirstOrDefaultAsync();
                if (trackedEntity == null) return null;
                return _mapper.Map<WorkspaceModel>(trackedEntity);
            } 
            catch (Exception)
            {
                throw;
            }
        }

        public Task<WorkspaceModel> GetWorkspaceByUniqueId(UnitOfWork unitOfWork, Guid workspaceGuid)
        {
            throw new NotImplementedException();
        }

        public Task<WorkspaceModel> CreateNewWorkspace(UnitOfWork unitOfWork, WorkspaceModel workspace)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateWorkspace(UnitOfWork unitOfWork, WorkspaceModel workspace)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteWorkspaceById(UnitOfWork unitOfWork, long workspaceId)
        {
            throw new NotImplementedException();
        }
    }
}
