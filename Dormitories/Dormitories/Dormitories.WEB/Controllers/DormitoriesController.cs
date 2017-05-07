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
        }


        public DormitoryFullDTO Get(int id)
        {
            return _dormitoryService.GetFullDormitory(id);
        }

        [HttpPut]
        public void Put([FromBody]DormitoryDTO floor)
        {
            _dormitoryService.UpdateDormitory(floor);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            _dormitoryService.DeleteDormitory(id);
            return true;

        }

        [HttpPost]
        public bool Post([FromBody]DormitoryDTO dormitory)
        {
            _dormitoryService.AddDormitory(dormitory);
            return true;
        }
    }
}
