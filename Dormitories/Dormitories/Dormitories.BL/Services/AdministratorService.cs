using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dormitories.BL.DTO_s;
using Dormitories.BL.Interfaces;
using Dormitories.DAL.Interfaces;

namespace Dormitories.BL.Services
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IUnitOfWork _uow;
        public AdministratorService(IUnitOfWorkFactory uowFactory)
        {
            _uow = uowFactory.Create();
        }

        public ICollection<AdministratorDTO> GetAllAdministrators()
        {
            var administrators = new List<AdministratorDTO>();

            using (_uow)
            {
                administrators = _uow.AdministratorRepository.Query().Select(d => new AdministratorDTO()
                {
                    Id = d.Id,
                    DormitoryId = d.DormitoryId,
                    FacultyId = d.FacultyId
                }).ToList();
            }

            return administrators;
        }
    }
}
