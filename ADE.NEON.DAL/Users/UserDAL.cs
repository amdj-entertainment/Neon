using ADE.NEON.DAL.Workspace;
using ADE.NEON.Shared.Models.Users;
using ADE.NEON.Shared.Models.Workspaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.DAL.Users
{
    public class UserDAL : IUserDAL
    {
        private readonly IMapper _mapper;
        private readonly IWorkspaceDAL _workspaceDAL;

        public UserDAL(IMapper mapper, IWorkspaceDAL workspaceDAL)
        {
            _mapper = mapper;
            _workspaceDAL = workspaceDAL;
        }

        public async Task<UserLimitedModel> GetCurrentUser(UnitOfWork unitOfWork, Guid userId)
        {
            var trackedEntity = await unitOfWork.NeonContext.NeonUsers
                .Include(x => x.UsersProfile)
                .FirstOrDefaultAsync(x => x.UserId == userId);
            if (trackedEntity == null) throw new NullReferenceException("User Not Found");

            var trackedWorkspaceEntity = await _workspaceDAL.GetWorkspaceById(unitOfWork, trackedEntity.WorkspaceUsers.FirstOrDefault(x => x.UserId == userId).WorkspaceId);
            if (trackedWorkspaceEntity == null) throw new NullReferenceException("A user must have a workspace");

            var user = _mapper.Map<UserLimitedModel>(trackedEntity);
            user.Workspace = _mapper.Map<WorkspaceLimitedModel>(trackedWorkspaceEntity);

            return user;
        }
    }
}
