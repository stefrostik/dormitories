using System.Collections.Generic;
using System.Web.Http;
using Dormitories.BL.DTO_s;
using Dormitories.BL.Interfaces;

namespace Dormitories.WEB.Controllers
{
    public class DormitoriesController : ApiController
    {
        private readonly IDormitoryService _dormitoryService;

        public DormitoriesController(IDormitoryService dormitoryService)
        {
            _dormitoryService = dormitoryService;
        }
        
        public ICollection<DormitoryDTO> Get()
        {
            //todo: implement fetching logic
            return _dormitoryService.GetAllDormitories();
           // return new List<DormitoryDTO>() { new DormitoryDTO() { Description= "sdfdsfsdfds" } };//_dormitoryService.GetAllDormitories();
        }
        

        public DormitoryFullDTO Get(int id)
        {
            return _dormitoryService.GetFullDormitory(id);
        }

    }
}
