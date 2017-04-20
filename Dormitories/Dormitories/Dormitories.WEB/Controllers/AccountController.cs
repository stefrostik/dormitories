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
            private readonly IAuthenticationService _authService;

            public AccountController(IAuthenticationService authService)
            {
                _authService = authService;
            }

            [AllowAnonymous]
            public async Task<IHttpActionResult> Register(UserRegisterDTO userModel)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var usr = new UserRegisterDTO()
                {
                    Name = "valeraJopta",
                    Email = "valeraJopta@gmail.com",
                    Password = "valeraJopta123456",
                    ConfirmPassword = "valeraJopta123456",
                    RoleName = "Student"
                };

                IdentityResult result = await _authService.RegisterUser(usr);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                return Ok();
            }

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