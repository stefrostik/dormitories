using System.Collections.Generic;
using Dormitories.BL.DTO_s;
using Dormitories.DAL.Models;

namespace Dormitories.BL.Interfaces
{
    public interface IFloorService
    {
        ICollection<FloorDTO> GetAllFloors();

        FloorDTO GetFloorById(int id);
        bool UpdateFloor(FloorDTO floor);
        bool DeleteFloor(int id);
        bool AddFloor(FloorDTO floor);
    }
}
