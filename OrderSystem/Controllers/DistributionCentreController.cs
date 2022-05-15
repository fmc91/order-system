using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLayer;
using DataLayer.Model;
using OrderSystem.Model;
using System.Linq.Expressions;
using DataLayer.Repositories;

namespace OrderSystem.Controllers
{
    [Route("api/centre")]
    [ApiController]
    public class DistributionCentreController : ControllerBase
    {
        private readonly IDistributionCentreRepository _distributionCentreRepository;

        private readonly IStockItemRepository _stockItemRepository;

        public DistributionCentreController(IDistributionCentreRepository distributionCentreRepository, IStockItemRepository stockItemRepository)
        {
            _distributionCentreRepository = distributionCentreRepository;
            _stockItemRepository = stockItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDistributionCentresAsync(int page = 0, int itemsPerPage = 20, int? countryId = null)
        {
            var result = await _distributionCentreRepository.GetAllAsync<DistributionCentreModel>(page, itemsPerPage, countryId);

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetDistributionCentresByNameSearchAsync(string query, int page = 0, int itemsPerPage = 20)
        {
            var result = await _distributionCentreRepository.GetByNameSearchAsync<DistributionCentreModel>(query, page, itemsPerPage);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDistributionCentreAsync(int id)
        {
            if (!await _distributionCentreRepository.ExistsAsync(id))
                return NotFound();

            var result = _distributionCentreRepository.GetByIdAsync<DistributionCentreModel>(id);
            return Ok(result);
        }

        [HttpGet("{id:int}/stock-item")]
        public async Task<IActionResult> GetStockItemsByDistributionCentreAsync(int id, int page = 0, int itemsPerPage = 20)
        {
            if (!await _distributionCentreRepository.ExistsAsync(id))
                return NotFound();

            var result = await _stockItemRepository.GetByDistributionCentreAsync<StockItemModel>(id, page, itemsPerPage);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDistributionCentreAsync([FromBody] DistributionCentreModel distributionCentre)
        {
            if (distributionCentre.DistributionCentreId != 0)
                return BadRequest();

            var result = await _distributionCentreRepository.AddAsync(distributionCentre);
            return CreatedAtAction("GetDistributionCentre", new { id = result.DistributionCentreId }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDistributionCentreAsync([FromBody] DistributionCentreModel distributionCentre)
        {
            if (distributionCentre.DistributionCentreId == 0)
                return BadRequest();

            if (!await _distributionCentreRepository.ExistsAsync(distributionCentre.DistributionCentreId))
                return NotFound();

            await _distributionCentreRepository.UpdateAsync(distributionCentre.DistributionCentreId, distributionCentre);
            return NoContent();
        }
    }
}
