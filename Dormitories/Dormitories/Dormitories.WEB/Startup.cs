using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Dormitories.WEB.Startup))]
namespace Dormitories.WEB
{

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
            HttpConfiguration config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);

            
        }
    }
}