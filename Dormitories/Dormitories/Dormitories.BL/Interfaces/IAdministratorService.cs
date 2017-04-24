using System.Collections.Generic;
using Dormitories.BL.DTO_s;

namespace Dormitories.BL.Interfaces
{
    public interface IAdministratorService
    {
        ICollection<AdministratorDTO> GetAllAdministrators();
        AdministratorDTO GetAdministratorById(int id);
        bool UpdateAdministrator(AdministratorDTO administrator);
        bool DeleteAdministrator(int id);
        bool AddAdministrator(AdministratorDTO administrator);
    }
}
