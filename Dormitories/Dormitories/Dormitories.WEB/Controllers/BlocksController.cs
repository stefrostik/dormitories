using System.Collections.Generic;
using System.Web.Http;
using Dormitories.BL.DTO_s;
using Dormitories.BL.Interfaces;

namespace Dormitories.WEB.Controllers
{
    public class BlocksController : ApiController
    {
        private readonly IBlockService _blockService;

        public BlocksController(IBlockService blockService)
        {
            _blockService = blockService;
        }
        public ICollection<BlockDTO> Get()
        {
            return _blockService.GetAllBlocks();
        }

        public BlockFullDTO Get(int id)
        {
            return _blockService.GetFullBlock(id);

        }
        [HttpPut]
        public void Put([FromBody]BlockDTO floor)
        {
            _blockService.UpdateBlock(floor);
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            _blockService.DeleteBlock(id);
            return true;

        }
        [HttpPost]
        public bool Post([FromBody]BlockDTO floor)
        {
            _blockService.AddBlock(floor);
            return true;
        }

    }
}
