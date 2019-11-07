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
            // Global
            builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>();

            // Events
            builder.RegisterType<EventsDAL>().As<IEventsDAL>();

            // User
            builder.RegisterType<UserDAL>().As<IUserDAL>();
            builder.RegisterType<UserProfileDAL>().As<IUserProfileDAL>();
            
            // Workspace
            builder.RegisterType<WorkspaceDAL>().As<IWorkspaceDAL>();
        }
    }
}
