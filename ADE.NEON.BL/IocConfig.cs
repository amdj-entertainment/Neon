using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADE.NEON.BL.Events;
using Autofac;

namespace ADE.NEON.BL
{
    public class IocConfig
    {
        public static void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterType<EventsBL>().As<IEventsBL>();
        }
    }
}
