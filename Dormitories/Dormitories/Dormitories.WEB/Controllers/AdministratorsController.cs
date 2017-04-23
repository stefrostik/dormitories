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
            //var drm = _floorService.GetAllFloors(); 
            return new List<AdministratorDTO>() { new AdministratorDTO() { Id=1, DormitoryId=2, FacultyId=3} };

        }

    }
}
