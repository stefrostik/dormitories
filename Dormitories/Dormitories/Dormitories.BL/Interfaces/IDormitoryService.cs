using System.Collections.Generic;
using Dormitories.BL.DTO_s;

namespace Dormitories.BL.Interfaces
{
    public interface IDormitoryService
    {
        ICollection<DormitoryDTO> GetAllDormitories();
    }
}
