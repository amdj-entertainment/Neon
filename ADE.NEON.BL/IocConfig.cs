using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADE.NEON.BL.Events;
using ADE.NEON.BL.User;
using ADE.NEON.BL.Workspace;
using Autofac;

namespace ADE.NEON.BL
{
    public static class IocConfig
    {
        public static void RegisterComponents(ContainerBuilder builder)
        {

            // Events
            builder.RegisterType<EventsBL>().As<IEventsBL>();

            // User
            builder.RegisterType<UserBL>().As<IUserBL>();
            builder.RegisterType<UserProfileBL>().As<IUserProfileBL>();

            // Workspace
            builder.RegisterType<WorkspaceBL>().As<IWorkspaceBL>();
        }
    }
}
