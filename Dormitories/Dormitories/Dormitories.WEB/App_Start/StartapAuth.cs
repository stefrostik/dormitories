using Dormitories.WEB.Providers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;


namespace Dormitories.WEB
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        //public static FacebookAuthenticationOptions FacebookAuthOptions { get; private set; }

        public void ConfigureOAuth(IAppBuilder app)
        {
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            app.UseCors(CorsOptions.AllowAll);

            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider =  new DormitoriesOAuthProvider(),
                //AccessTokenExpireTimeSpan = new TimeSpan(3600),/*LvivCyclingConsts.DefaultTokenExpirationTime*/
                AllowInsecureHttp = true
            };


            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}