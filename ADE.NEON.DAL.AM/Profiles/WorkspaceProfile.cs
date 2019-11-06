using ADE.NEON.DAL.EF;
using ADE.NEON.Shared.Models.Workspaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.DAL.AM.Profiles
{
    public class WorkspaceProfile : Profile
    {
        public WorkspaceProfile()
        {
            CreateMap<Workspace, WorkspaceModel>();
            CreateMap<WorkspaceModel, Workspace>();

            CreateMap<WorkspaceUser, WorkspaceUserModel>();
            CreateMap<WorkspaceUserModel, WorkspaceUser>();
        }
    }
}
