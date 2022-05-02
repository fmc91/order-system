using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DomainLayer;
using DomainLayer.DistributionCentreModel;

namespace OrderSystem.Controllers
{
    [Route("api/centre")]
    [ApiController]
    public class DistributionCentreController : ControllerBase
    {
        private readonly IDistributionCentreService _distributionCentreService;

        public DistributionCentreController(IDistributionCentreService distributionCentreService)
        {
            _distributionCentreService = distributionCentreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDistributionCentresAsync(int page = 0, int itemsPerPage = 20)
        {
            var result = await _distributionCentreService.GetAllDistributionCentresAsync(page, itemsPerPage);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetDistributionCentresByNameSearchAsync(string query, int page = 0, int itemsPerPage = 20)
        {
            var result = await _distributionCentreService.GetDistributionCentresByNameSearchAsync(query, page, itemsPerPage);
            return Ok(result);
        }

        [HttpGet("location")]
        public async Task<IActionResult> GetDistributionCentresByCountryCodeAsync(string country, int page = 0, int itemsPerPage = 20)
        {
            var result = await _distributionCentreService.GetDistributionCentresByCountryCodeAsync(country, page, itemsPerPage);
            return Ok(result);
        }

        [HttpGet("{int:id}")]
        public async Task<IActionResult> GetDistributionCentreAsync(int id)
        {
            try
            {
                var result = await _distributionCentreService.GetDistributionCentreByIdAsync(id);
                return Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { errorMessage = ex.Message });
            }
        }

        [HttpGet("{int:id}/stock-item")]
        public async Task<IActionResult> GetStockItemsByDistributionCentreAsync(int id, int page = 0, int itemsPerPage = 20)
        {
            var result = await _distributionCentreService.GetStockItemsByDistributionCentreAsync(id, page, itemsPerPage);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDistributionCentreAsync([FromBody] DistributionCentre distributionCentre)
        {
            try
            {
                var result = await _distributionCentreService.CreateDistributionCentreAsync(distributionCentre);
                return CreatedAtAction("GetDistributionCentre", new { id = result.DistributionCentreId }, result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { errorMessage = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDistributionCentreAsync([FromBody] DistributionCentre distributionCentre)
        {
            try
            {
                await _distributionCentreService.UpdateDistributionCentreAsync(distributionCentre);
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
