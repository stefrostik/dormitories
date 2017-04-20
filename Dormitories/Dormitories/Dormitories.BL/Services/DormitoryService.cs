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
    public class DormitoryService : IDormitoryService
    {
        private readonly IUnitOfWork _uow;
        public DormitoryService(IUnitOfWorkFactory uowFactory)
        {
            _uow = uowFactory.Create();
        }

        public ICollection<DormitoryDTO> GetAllDormitories()
        {
            var dormitories = new List<DormitoryDTO>();

            using (_uow)
            {
                dormitories = _uow.DormitoryRepository.Query().Select(d => new DormitoryDTO()
                {
                    Description = d.Description,
                    Address = d.Address
                }).ToList();
            }

            return dormitories;
        }
    }
}
