using Dormitories.DAL;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Dormitories.BL;

namespace Dormitories.WEB
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var serv = new Service();
            serv.Test();
            serv.Test2();
        }
    }
}
