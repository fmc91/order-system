using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLayer;
using DataLayer.Model;
using OrderSystem.Model;

namespace OrderSystem.Controllers
{
    [Route("api/centre")]
    [ApiController]
    public class DistributionCentreController : ControllerBase
    {
        private readonly IRepository<DistributionCentre> _distributionCentreRepository;

        private readonly IRepository<StockItem> _stockItemRepository;

        public DistributionCentreController(RepositoryProvider repositoryProvider)
        {
            _distributionCentreRepository = repositoryProvider.GetRepository<DistributionCentre>();
            _stockItemRepository = repositoryProvider.GetRepository<StockItem>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDistributionCentresAsync(string? country = null, int page = 0, int itemsPerPage = 20)
        {
            var result = country == null ?
                await _distributionCentreRepository.QueryAsync<DistributionCentreModel>(x => x
                    .OrderBy(c => c.Name)
                    .Skip(page * itemsPerPage)
                    .Take(itemsPerPage)) :
                await _distributionCentreRepository.QueryAsync<DistributionCentreModel>(x => x
                    .Where(c => c.DistributionCentreAddress.Address.Country.CountryCode == country)
                    .OrderBy(c => c.Name)
                    .Skip(page * itemsPerPage)
                    .Take(itemsPerPage));

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetDistributionCentresByNameSearchAsync(string query, int page = 0, int itemsPerPage = 20)
        {
            var result = await _distributionCentreRepository.QueryAsync<DistributionCentreModel>(x => x
                .Where(c => c.Name.Contains(query))
                .OrderBy(c => c.Name)
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage));

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

            var result = await _stockItemRepository.QueryAsync<StockItemModel>(x => x
                .Where(i => i.DistributionCentreId == id)
                .OrderBy(i => i.Product.Name)
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage));

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
