using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(ADE.NEON.API.Startup))]
namespace ADE.NEON.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            builder.UseCors(CorsOptions.AllowAll);
            ConfigureAuth(builder);
        }
    }
}