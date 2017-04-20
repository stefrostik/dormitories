using Dormitories.BL;
using Dormitories.BL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;


namespace Dormitories.WEB.Controllers
{
    namespace LvivCycling.Controllers.ApiControllers
    {
        [Authorize]
        [RoutePrefix("api/Account")]
        public class AccountController : ApiController
        {
            private readonly IAuthenticationService authService;

            public AccountController( /*IAuthenticationService authService*/)
            {
                this.authService = new BL.Identity.AuthenticationService();
            }

            [AllowAnonymous]
            public async Task<IHttpActionResult> Register(UserRegisterDTO userModel)
            {
                //if (!ModelState.IsValid)
                //{
                //    return BadRequest(ModelState);
                //}

                var usr = new UserRegisterDTO()
                {
                    Name = "valeraJopta",
                    Email = "valeraJopta@gmail.com",
                    Password = "valeraJopta123456",
                    ConfirmPassword = "valeraJopta123456",
                    RoleName = "Student"
                };

                IdentityResult result = await authService.RegisterUser(usr);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                return Ok();
            }

            //[OverrideAuthentication]
            //[HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
            //[AllowAnonymous]
            //[Route("ExternalLogin", Name = "ExternalLogin")]
            //public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
            //{
            //    if (error != null)
            //    {
            //        return BadRequest(Uri.EscapeDataString(error));
            //    }

            //    if (!User.Identity.IsAuthenticated)
            //    {
            //        return new ChallengeResult(provider, this);
            //    }

            //    ExternalLoginData externalLogin = authService
            //        .GetExternalDataFromIdentity(User.Identity as ClaimsIdentity);

            //    if (externalLogin == null)
            //    {
            //        return InternalServerError();
            //    }

            //    if (externalLogin.LoginProvider != provider)
            //    {
            //        Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            //        return new ChallengeResult(provider, this);
            //    }

            //    UserLoginInfo info = new UserLoginInfo(externalLogin.LoginProvider, externalLogin.ProviderKey);

            //    bool hasRegistered = await authService.HasRegistered(info);

            //    if (!hasRegistered)
            //    {
            //        IdentityResult result = await authService
            //            .RegisterExternalAsync(externalLogin);

            //        if (!result.Succeeded)
            //        {
            //            return GetErrorResult(result);
            //        }
            //    }

            //    var user = await authService.FindAsync(info);
            //    var accessTokenResponse = authService.GenerateLocalAccessTokenResponse(user, Startup.OAuthOptions);

            //    var urlBase = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            //    var redirectUrl = urlBase + LvivCyclingConsts.CompleteRegistrationPage;
            //    var rolesString = await authService.GetAllRolesJson(user.Id);
            //    var redirectUri = string.Format(
            //        "{0}#token={1}&roles={2}&userName={3}&id={4}&isBlocked={5}",
            //        redirectUrl,
            //        accessTokenResponse,
            //        rolesString,
            //        user.UserName,
            //        user.Id,
            //        user.LockoutEnabled);

            //    Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            //    return Redirect(redirectUri);
            //}

            private IHttpActionResult GetErrorResult(IdentityResult result)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("errors", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }
        }
    }
}