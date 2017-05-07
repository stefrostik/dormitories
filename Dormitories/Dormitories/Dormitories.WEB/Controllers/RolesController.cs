using System.Web.Http;
using Dormitories.BL.Interfaces;

namespace Dormitories.WEB.Controllers
{
    public class RolesController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public RolesController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IHttpActionResult Get()
        {
            var roles = _authenticationService.GetAllRoles();
            //todo: map to dto
            return Json(roles);
        }
    }
}
