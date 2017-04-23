using System.Collections.Generic;
using Dormitories.BL.DTO_s;

namespace Dormitories.BL.Interfaces
{
    public interface IBlockService
    {
        ICollection<BlockDTO> GetAllBlocks();
        BlockDTO GetBlockById(int id);
        bool UpdateBlock(BlockDTO block);
        bool DeleteBlock(int id);
        bool AddBlock(BlockDTO block);
    }
}
