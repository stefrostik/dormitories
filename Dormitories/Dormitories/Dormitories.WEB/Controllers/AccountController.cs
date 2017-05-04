using System.Threading.Tasks;
using System.Web.Http;
using Dormitories.BL;
using Dormitories.BL.Interfaces;
using Microsoft.AspNet.Identity;

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

                IdentityResult result = await _authService.RegisterUser(userModel);

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