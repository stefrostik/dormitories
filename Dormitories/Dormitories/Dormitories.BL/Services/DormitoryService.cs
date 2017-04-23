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
        public bool UpdateDormitory(DormitoryDTO dormitory)
        {
            using (_uow)
            {
                var tempDormitory = _uow.DormitoryRepository.GetById(dormitory.Id);
                tempDormitory.Address = dormitory.Address;
                tempDormitory.Description = dormitory.Description;
                tempDormitory.ComendantId = dormitory.ComendantId;
                tempDormitory.Number = dormitory.Number;
                _uow.DormitoryRepository.Update(tempDormitory);
                _uow.Save();
            }
            return true;
        }
        public bool DeleteDormitory(int id)
        {
            using (_uow)
            {
                var tempDormitory = _uow.DormitoryRepository.GetById(id);
                _uow.DormitoryRepository.Delete(tempDormitory);
                _uow.Save();
            }
            return true;
        }
        public bool AddDormitory(DormitoryDTO dormitory)
        {
            using (_uow)
            {
                Dormitory tempDormitory = new Dormitory();
                tempDormitory.Address = dormitory.Address;
                tempDormitory.Description = dormitory.Description;
                tempDormitory.ComendantId = dormitory.ComendantId;
                tempDormitory.Number = dormitory.Number;
                _uow.DormitoryRepository.Insert(tempDormitory);
                _uow.Save();
            }
            return true;
        }
    }
}
