using ADE.NEON.Shared.Models.Workspaces;
using ADE.NEON.Shared.Utilities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADE.NEON.DAL.EF;

namespace ADE.NEON.DAL.Workspace
{
    public class WorkspaceDAL : IWorkspaceDAL
    {
        private readonly ICurrentTimeProvider _currentTimeProvider;
        private readonly IUniqueIdProvider _uniqueIdProvider;
        private readonly IMapper _mapper;

        public WorkspaceDAL(ICurrentTimeProvider currentTimeProvider, IUniqueIdProvider uniqueIdProvider, IMapper mapper)
        {
            _currentTimeProvider = currentTimeProvider;
            _uniqueIdProvider = uniqueIdProvider;
            _mapper = mapper;
        }

        public async Task<WorkspaceModel> GetWorkspaceById(UnitOfWork unitOfWork, long workspaceId)
        {
            try
            {
                var trackedEntity = await unitOfWork.NeonContext.Workspaces.Where(x => x.Id == workspaceId).FirstOrDefaultAsync();
                return trackedEntity == null ? null : _mapper.Map<WorkspaceModel>(trackedEntity);
            } 
            catch (Exception)
            {
                // TODO: LOG ERROR
                throw;
            }
        }

        public Task<WorkspaceModel> GetWorkspaceByUniqueId(UnitOfWork unitOfWork, Guid workspaceGuid)
        {
            throw new NotImplementedException();
        }

        public async Task<WorkspaceModel> CreateNewWorkspace(UnitOfWork unitOfWork, WorkspaceModel workspace)
        {
            var trackedEntity = await unitOfWork.NeonContext.Workspaces.FirstOrDefaultAsync(x => x.Id == workspace.Id);
            if (trackedEntity != null) throw new EntityException("Workspace already exists");

            var spaceUsers = _mapper.Map<ICollection<WorkspaceUser>>(workspace.WorkspaceUsers);
            foreach (var user in spaceUsers)
            {
                user.UniqueId = _uniqueIdProvider.NewUniqueId;
                user.LastUpdate = _currentTimeProvider.LocalDateTime;
                user.CreateDate = _currentTimeProvider.LocalDateTime;
            }


            var space = new EF.Workspace
            {
                UniqueId = _uniqueIdProvider.NewUniqueId,
                Name = workspace.Name,
                WorkspaceUsers = spaceUsers,
                LastUpdate = _currentTimeProvider.LocalDateTime,
                CreateDate = _currentTimeProvider.LocalDateTime,
            };

            trackedEntity = unitOfWork.NeonContext.Workspaces.Add(space);

            return _mapper.Map<WorkspaceModel>(trackedEntity);
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
