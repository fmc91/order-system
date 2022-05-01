using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderSystem.Controllers
{
    [Route("api/stock-item")]
    [ApiController]
    public class StockItemController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateStockItemAsync([FromBody] object stockItem)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStockItemAsync([FromBody] object stockItem)
        {
            throw new NotImplementedException();
        }
    }
}
