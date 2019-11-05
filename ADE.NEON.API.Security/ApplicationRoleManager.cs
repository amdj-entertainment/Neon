using System;
using ADE.NEON.API.Security.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace ADE.NEON.API.Security
{
    public class ApplicationRoleManager : RoleManager<GuidRole, Guid>
    {
        public ApplicationRoleManager(IRoleStore<GuidRole, Guid> roleStore) : base(roleStore) {}

        public static ApplicationRoleManager Create<TDbContextType>(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context) where TDbContextType : ADESecurityContext
        {
            return new ApplicationRoleManager(new RoleStore<GuidRole, Guid, GuidUserRole>(context.Get<TDbContextType>()));
        }

        /// <summary>
        /// Theses roles should mirror the system claims values and in the database
        /// </summary>
        public static class RoleNames
        {
            public const string SystemAdministrator = @"SystemAdministrator";
            public const string SystemModerator = @"SystemModerator";
            public const string SystemSupport = @"SystemSupport";
            public const string SystemEditor = @"SystemEditor";
            public const string StandardUser = @"StandardUser";
        }
    }
}