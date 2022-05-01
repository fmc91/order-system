using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderSystem.Controllers
{
    [Route("api/centre")]
    [ApiController]
    public class DistributionCentreController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllDistributionCentresAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetDistributionCentresByNameSearchAsync(string query)
        {
            throw new NotImplementedException();
        }

        [HttpGet("location")]
        public async Task<IActionResult> GetDistributionCentresByLocationSearchAsync(double lat, double lon)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{int:id}")]
        public async Task<IActionResult> GetDistributionCentreAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{int:id}/stock-item")]
        public async Task<IActionResult> GetStockItemsByDistributionCentreAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDistributionCentreAsync([FromBody] object distributionCentre)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDistributionCentreAsync([FromBody] object distributionCentre)
        {
            throw new NotImplementedException();
        }
    }
}
