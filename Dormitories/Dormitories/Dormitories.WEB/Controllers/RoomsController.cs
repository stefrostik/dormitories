using System.Collections.Generic;
using System.Web.Http;
using Dormitories.BL.DTO_s;
using Dormitories.BL.Interfaces;

namespace Dormitories.WEB.Controllers
{
    public class RoomsController : ApiController
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public ICollection<RoomDTO> Get()
        {
            return _roomService.GetAllRooms();
        }
        public RoomFullDTO Get(int id)
        {
            return _roomService.GetFullRoom(id);
        }
        [HttpPut]
        public void Put([FromBody]RoomDTO room)
        {
            _roomService.UpdateRoom(room);
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            _roomService.DeleteRoom(id);
            return true;
        }
        [HttpPost]
        public bool Post([FromBody]RoomDTO room)
        {
            _roomService.AddRoom(room);
            return true;
        }
    }
}
