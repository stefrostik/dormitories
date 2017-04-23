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
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _uow;
        public RoomService(IUnitOfWorkFactory uowFactory)
        {
            _uow = uowFactory.Create();
        }

        public ICollection<RoomDTO> GetAllRooms()
        {
            using (_uow)
            {
                return _uow.RoomRepository.Query().Select(d => new RoomDTO()
                {
                    Id = d.Id,
                    BlockId = d.BlockId,
                    FacultyId = d.FacultyId,
                    TotalPlaces = d.TotalPlaces
                }).ToList();
            }
            
        }
        public RoomDTO GetRoomById(int id)
        {
            using (_uow)
            {
                return _uow.RoomRepository.Query().Select(d => new RoomDTO() {
                    Id = d.Id,
                    BlockId = d.BlockId,
                    FacultyId = d.FacultyId,
                    TotalPlaces = d.TotalPlaces
                }).FirstOrDefault();         
            }    
        }

        public bool UpdateRoom(RoomDTO room)
        {
            using (_uow)
            {
                var tempRoom = _uow.RoomRepository.GetById(room.Id);
                tempRoom.TotalPlaces = room.TotalPlaces;
                tempRoom.BlockId = room.BlockId;
                tempRoom.FacultyId = room.FacultyId;

                _uow.RoomRepository.Update(tempRoom);
                _uow.Save();  
            }
            return true;
        }

        public bool DeleteRoom(int id)
        {
            using (_uow)
            {                
                var tempRoom = _uow.RoomRepository.GetById(id);
                _uow.RoomRepository.Delete(tempRoom);
                _uow.Save();
            }
            return true;
        }

        public bool AddRoom(RoomDTO room)
        {
            using (_uow)
            {
                Room tempRoom = new Room();
                tempRoom.TotalPlaces = room.TotalPlaces;
                tempRoom.BlockId = room.BlockId;
                tempRoom.FacultyId = room.FacultyId;
                _uow.RoomRepository.Insert(tempRoom);
                _uow.Save();
            }
            return true;
        }

    }
}
