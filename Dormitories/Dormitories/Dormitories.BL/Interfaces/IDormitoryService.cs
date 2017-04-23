using System.Collections.Generic;
using Dormitories.BL.DTO_s;

namespace Dormitories.BL.Interfaces
{
    public interface IDormitoryService
    {
        ICollection<DormitoryDTO> GetAllDormitories();
        DormitoryFullDTO GetFullDormitory(int id);
        bool UpdateDormitory(DormitoryDTO dormitory);
        bool DeleteDormitory(int id);
        bool AddDormitory(DormitoryDTO dormitory);
    }
}
