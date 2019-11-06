using ADE.NEON.API.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;

namespace ADE.NEON.API
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Database.SetInitializer<NeonSecurityDbContext>(null);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            IocConfig.Initialize();
        }
    }
}