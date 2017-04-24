using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dormitories.BL.DTO_s;
using Dormitories.BL.Interfaces;
using Dormitories.DAL.Interfaces;
using Dormitories.DAL.Models;

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
        public AdministratorDTO GetAdministratorById(int id)
        {
            using (_uow)
            {
                return _uow.AdministratorRepository.Query().Select(d => new AdministratorDTO()
                {
                    Id = d.Id,
                    DormitoryId = d.DormitoryId,
                    FacultyId = d.FacultyId
                }).FirstOrDefault();
            }
        }

        public bool UpdateAdministrator(AdministratorDTO administrator)
        {
            using (_uow)
            {
                var tempAdministrator = _uow.AdministratorRepository.GetById(administrator.Id);
                tempAdministrator.DormitoryId = administrator.DormitoryId;
                tempAdministrator.FacultyId = administrator.FacultyId;
                _uow.AdministratorRepository.Update(tempAdministrator);
                _uow.Save();
            }
            return true;
        }

        public bool DeleteAdministrator(int id)
        {
            using (_uow)
            {
                var tempAdministrator = _uow.AdministratorRepository.GetById(id);
                _uow.AdministratorRepository.Delete(tempAdministrator);
                _uow.Save();
            }
            return true;
        }

        public bool AddAdministrator(AdministratorDTO administrator)
        {
            using (_uow)
            {
                Administrator tempAdministrator = new Administrator();
                tempAdministrator.DormitoryId = administrator.DormitoryId;
                tempAdministrator.FacultyId = administrator.FacultyId;
                _uow.AdministratorRepository.Insert(tempAdministrator);
                _uow.Save();
            }
            return true;
        }
    }
}
