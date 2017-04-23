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
    public class BlockService : IBlockService
    {
        private readonly IUnitOfWork _uow;
        public BlockService(IUnitOfWorkFactory uowFactory)
        {
            _uow = uowFactory.Create();
        }

        public ICollection<BlockDTO> GetAllBlocks()
        {
            var blocks = new List<BlockDTO>();

            using (_uow)
            {
                blocks = _uow.BlockRepository.Query().Select(d => new BlockDTO()
                {
                    Id = d.Id,
                    FloorId = d.FloorId
                }).ToList();
            }

            return blocks;
        }
        public BlockFullDTO GetFullBlock(int id)
        {

            using (_uow)
            {
                var block = _uow.BlockRepository.GetById(id);
                if (block != null)
                {
                    var fullBlockDto = new BlockFullDTO()
                    {
                        Id = block.Id,
                        FloorId = block.FloorId,
                        Rooms = block.Rooms.Select(x => new RoomDTO()
                        {
                            Id = x.Id,
                            BlockId = x.BlockId,
                            FacultyId = x.FacultyId,
                            TotalPlaces = x.TotalPlaces
                        }).ToList()
                    };
                    return fullBlockDto;
                }
                else return new BlockFullDTO();
            }
        }
        public BlockDTO GetBlockById(int id)
        {
            using (_uow)
            {
                return _uow.BlockRepository.Query().Select(d => new BlockDTO()
                {
                    Id = d.Id,
                    FloorId = d.FloorId
                }).FirstOrDefault();
            }
        }

        public bool UpdateBlock(BlockDTO block)
        {
            using (_uow)
            {
                var tempBlock = _uow.BlockRepository.GetById(block.Id);
                tempBlock.FloorId = block.FloorId;
                _uow.BlockRepository.Update(tempBlock);
                _uow.Save();
            }
            return true;
        }

        public bool DeleteBlock(int id)
        {
            using (_uow)
            {
                var tempBlock = _uow.BlockRepository.GetById(id);
                _uow.BlockRepository.Delete(tempBlock);
                _uow.Save();
            }
            return true;
        }

        public bool AddBlock(BlockDTO block)
        {
            using (_uow)
            {
                Block tempBlock = new Block();
                tempBlock.FloorId = block.FloorId;
                _uow.BlockRepository.Insert(tempBlock);
                _uow.Save();
            }
            return true;
        }
    }
}
