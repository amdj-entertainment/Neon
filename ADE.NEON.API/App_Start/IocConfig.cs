using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace ADE.NEON.API
{
    public static class IocConfig
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            BL.IocConfig.RegisterComponents(builder);
            DAL.IocConfig.RegisterComponents(builder);
            DAL.AM.IocConfig.RegisterComponents(builder);
            Shared.IocConfig.RegisterComponents(builder);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;

        }
    }
}