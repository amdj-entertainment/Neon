using ADE.NEON.Shared.Utilities;
using Autofac;

namespace ADE.NEON.Shared
{
    public class IocConfig
    {
        public static void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterType<CurrentTimeProvider>().As<ICurrentTimeProvider>();
            builder.RegisterType<UniqueIdProvider>().As<IUniqueIdProvider>();
        }
    }
}
