using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLayer;
using DataLayer.Model;
using OrderSystem.Model;

namespace OrderSystem.Controllers
{
    [Route("api/stock-item")]
    [ApiController]
    public class StockItemController : ControllerBase
    {
        private readonly IRepository<StockItem> _stockItemRepository;

        public StockItemController(RepositoryProvider repositoryProvider)
        {
            _stockItemRepository = repositoryProvider.GetRepository<StockItem>();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStockItemAsync([FromBody] StockItemModel stockItem)
        {
            bool isBadRequest =
                stockItem.DistributionCentreId == 0 ||
                stockItem.ProductId == 0 ||
                await _stockItemRepository.ExistsAsync(new { stockItem.DistributionCentreId, stockItem.ProductId });

            if (isBadRequest)
                return BadRequest();

            await _stockItemRepository.AddAsync(stockItem);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStockItemAsync([FromBody] StockItemModel stockItem)
        {
            bool isBadRequest =
                stockItem.DistributionCentreId == 0 ||
                stockItem.ProductId == 0 ||
                !await _stockItemRepository.ExistsAsync(new { stockItem.DistributionCentreId, stockItem.ProductId });

            if (isBadRequest)
                return BadRequest();

            await _stockItemRepository.UpdateAsync(new { stockItem.DistributionCentreId, stockItem.ProductId }, stockItem);
            return NoContent();
        }
    }
}
