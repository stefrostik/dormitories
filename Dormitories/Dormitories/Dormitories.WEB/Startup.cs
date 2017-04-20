using System.Web.Http;
using Dormitories.WEB.App_Start;
using Microsoft.Owin;
using Microsoft.Practices.Unity.WebApi;
using Owin;


[assembly: OwinStartup(typeof(Dormitories.WEB.Startup))]
namespace Dormitories.WEB
{

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

            config.DependencyResolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer());

            app.UseWebApi(config);
        }
    }
}