using System.Collections.Generic;
using Dormitories.BL.DTO_s;

namespace Dormitories.BL.Interfaces
{
    public interface IRoomService
    {
        ICollection<RoomDTO> GetAllRooms();
        RoomDTO GetRoomById(int id);
        bool UpdateRoom(RoomDTO room);
        bool DeleteRoom(int id);
        bool AddRoom(RoomDTO room);
    }
}
