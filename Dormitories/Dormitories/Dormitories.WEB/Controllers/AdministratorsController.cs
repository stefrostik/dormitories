using System.Collections.Generic;
using System.Web.Http;
using Dormitories.BL.DTO_s;
using Dormitories.BL.Interfaces;

namespace Dormitories.WEB.Controllers
{
    public class AdministratorsController : ApiController
    {
        private readonly IAdministratorService _administratorService;

        public AdministratorsController(IAdministratorService administatorService)
        {
            _administratorService = administatorService;
        }

        public ICollection<AdministratorDTO> Get()
        {
            return _administratorService.GetAllAdministrators();
        }
        public AdministratorDTO Get(int id)
        {
            return _administratorService.GetAdministratorById(id);
        }

        [HttpPut]
        public void Put([FromBody]AdministratorDTO administrator)
        {
            _administratorService.UpdateAdministrator(administrator);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            _administratorService.DeleteAdministrator(id);
            return true;

        }

        [HttpPost]
        public bool Post([FromBody]AdministratorDTO administrator)
        {
            _administratorService.AddAdministrator(administrator);
            return true;
        }

    }
}
