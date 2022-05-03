using DomainLayer;
using DomainLayer.DistributionCentreModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderSystem.Controllers
{
    [Route("api/stock-item")]
    [ApiController]
    public class StockItemController : ControllerBase
    {
        private readonly IDistributionCentreService _distributionCentreController;

        public StockItemController(IDistributionCentreService distributionCentreController)
        {
            _distributionCentreController = distributionCentreController;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStockItemAsync([FromBody] StockItem stockItem)
        {
            try
            {
                var result = await _distributionCentreController.CreateStockItemAsync(stockItem);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { errorMessage = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStockItemAsync([FromBody] StockItem stockItem)
        {
            try
            {
                await _distributionCentreController.UpdateStockItemAsync(stockItem);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { errorMessage = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { errorMessage = ex.Message });
            }
        }
    }
}
