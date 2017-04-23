using System.Collections.Generic;
using System.Web.Http;
using Dormitories.BL.DTO_s;
using Dormitories.BL.Interfaces;

namespace Dormitories.WEB.Controllers
{
    public class FloorsController : ApiController
    {
        private readonly IFloorService _floorService;

        public FloorsController(IFloorService floorService)
        {
            _floorService = floorService;
        }
        public ICollection<FloorDTO> Get()
        {
            return _floorService.GetAllFloors();
        }

        public FloorFullDTO Get(int id)
        {
            return _floorService.GetFullFloor(id);
            //return new FloorDTO() { Number = 4, Id = 2 } ;

        }
        [HttpPut]
        public void Put([FromBody]FloorDTO floor)
        {
            _floorService.UpdateFloor(floor);
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            _floorService.DeleteFloor(id);
            return true;

        }
        [HttpPost]
        public bool Post([FromBody]FloorDTO floor)
        {
            _floorService.AddFloor(floor);
            return true;
        }

    }
}
