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
                    Id = d.Id,
                    Description = d.Description,
                    Address = d.Address,
                    ComendantId = d.ComendantId,
                    Number = d.Number
                }).ToList();
            }

            return dormitories;
        }
        public ICollection<FloorDTO> GetAllFloorsByDormitoryId(int id)
        {
            var floors = new List<FloorDTO>();
            using (_uow)
            {
                floors = _uow.FloorRepository.Query().Where(d => d.DormitoryId == id).Select(d => new FloorDTO()
                {
                    Id = d.Id,
                    Number = d.Number,
                    DormitoryId = d.DormitoryId
                }).ToList();
            }
            return floors;
        }

        public DormitoryFullDTO GetFullDormitory(int id) {
           
            using (_uow)
            {
                var dormitory = _uow.DormitoryRepository.GetById(id);
                if (dormitory != null)
                {
                    var fullDormitoryDto = new DormitoryFullDTO()
                    {
                        Id = dormitory.Id,
                        Description = dormitory.Description,
                        Address = dormitory.Address,
                        ComendantId = dormitory.ComendantId,
                        Number = dormitory.Number,
                        Floors = dormitory.Floors.Select(x => new FloorDTO()
                        {
                            Id = x.Id,
                            Number = x.Number,
                            DormitoryId = x.DormitoryId
                        }).ToList()
                    };
                    return fullDormitoryDto;
                }
                else return new DormitoryFullDTO();
            }
        }
    }
}
