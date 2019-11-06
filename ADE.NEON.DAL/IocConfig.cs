using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADE.NEON.DAL.Events;
using ADE.NEON.DAL.Users;
using ADE.NEON.DAL.Workspace;
using Autofac;

namespace ADE.NEON.DAL
{
    public static class IocConfig
    {
        public static void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>();
            builder.RegisterType<EventsDAL>().As<IEventsDAL>();
            builder.RegisterType<UserProfileDAL>().As<IUserProfileDAL>();
            builder.RegisterType<WorkspaceDAL>().As<IWorkspaceDAL>();
        }
    }
}
