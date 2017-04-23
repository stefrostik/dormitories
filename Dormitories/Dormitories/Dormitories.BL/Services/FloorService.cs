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
    public class FloorService : IFloorService
    {
        private readonly IUnitOfWork _uow;
        public FloorService(IUnitOfWorkFactory uowFactory)
        {
            _uow = uowFactory.Create();
        }

        public ICollection<FloorDTO> GetAllFloors()
        {
            using (_uow)
            {
                return _uow.FloorRepository.Query().Select(d => new FloorDTO()
                {
                    Id = d.Id,
                    Number = d.Number,
                    DormitoryId = d.DormitoryId
                }).ToList();
            }
            
        }
        public FloorDTO GetFloorById(int id)
        {
            using (_uow)
            {
                return _uow.FloorRepository.Query().Select(d => new FloorDTO() {
                    Id = d.Id,
                    Number = d.Number,
                    DormitoryId = d.DormitoryId
                }).FirstOrDefault();         
            }    
        }

        public bool UpdateFloor(FloorDTO floor)
        {
            using (_uow)
            {
                var tempFlor = _uow.FloorRepository.GetById(floor.Id);
                tempFlor.Number = floor.Number;
                _uow.FloorRepository.Update(tempFlor);
                _uow.Save();  
            }
            return true;
        }

        public bool DeleteFloor(int id)
        {
            using (_uow)
            {                
                var tempFlor = _uow.FloorRepository.GetById(id);
                _uow.FloorRepository.Delete(tempFlor);
                _uow.Save();
            }
            return true;
        }

        public bool AddFloor(FloorDTO floor)
        {
            using (_uow)
            {
                Floor tempFloor = new Floor();
                tempFloor.Number = floor.Number;
                tempFloor.DormitoryId = floor.DormitoryId;
                _uow.FloorRepository.Insert(tempFloor);
                _uow.Save();
            }
            return true;
        }

    }
}
