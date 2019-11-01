using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADE.NEON.DAL.AM.Profiles;
using Autofac;
using AutoMapper;

namespace ADE.NEON.DAL.AM
{
    public class IocConfig
    {
        public static void RegisterComponents(ContainerBuilder builder)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AddressesProfile>();
                cfg.AddProfile<EventsProfile>();
                cfg.AddProfile<UsersProfile>();
                cfg.AddProfile<VenuesProfile>();
            });

            builder.RegisterType<Mapper>().As<IMapper>().WithParameter("configurationProvider", configuration);
        }
    }
}
