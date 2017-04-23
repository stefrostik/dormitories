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
    }
}
