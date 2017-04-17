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
                TokenEndpointPath = new PathString("/token"/*LvivCyclingConsts.TokenPath*/),
                Provider =  new DormitoriesOAuthProvider(),//new LvivCyclingOAuthProvider(NinjectWebCommon.Kernel.GetService<IAuthenticationService>()),
                //AccessTokenExpireTimeSpan = new TimeSpan(3600),/*LvivCyclingConsts.DefaultTokenExpirationTime*/
                AllowInsecureHttp = true
            };

            //FacebookAuthOptions = new FacebookAuthenticationOptions()
            //{
            //    AppId = ConfigurationManager.AppSettings["FbId"],
            //    AppSecret = ConfigurationManager.AppSettings["FbAs"],
            //    Provider = new FacebookAuthProvider()
            //};

            //FacebookAuthOptions.Scope.Add("email");

            app.UseOAuthBearerTokens(OAuthOptions);
            //app.UseFacebookAuthentication(FacebookAuthOptions);
        }
    }
}