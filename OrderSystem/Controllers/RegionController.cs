using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLayer;
using DataLayer.Model;
using OrderSystem.Model;
using DataLayer.Repositories;

namespace OrderSystem.Controllers
{
    [Route("api/region")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;

        private readonly ICustomerRepository _customerRepository;

        private readonly IOrderRepository _orderRepository;

        public RegionController(IRegionRepository regionRepository, ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            _regionRepository = regionRepository;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync(int page, int itemsPerPage)
        {
            var result = await _regionRepository.GetAllAsync<RegionModel>(page, itemsPerPage);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRegionAsync(int id)
        {
            if (!await _regionRepository.ExistsAsync(id))
                return NotFound();

            var result = await _regionRepository.GetByIdAsync<RegionModel>(id);
            return Ok(result);
        }

        [HttpGet("{id:int}/customer")]
        public async Task<IActionResult> GetCustomersByRegionAsync(int id, int page, int itemsPerPage)
        {
            if (!await _regionRepository.ExistsAsync(id))
                return NotFound();

            var result = await _customerRepository.GetByRegionAsync<CustomerModel>(id, page, itemsPerPage);

            return Ok(result);
        }

        [HttpGet("{id:int}/order")]
        public async Task<IActionResult> GetOrdersByRegionAsync(int id, int page, int itemsPerPage)
        {
            if (!await _regionRepository.ExistsAsync(id))
                return NotFound();

            var result = await _orderRepository.GetByRegionAsync<OrderModel>(id, page, itemsPerPage);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegionAsync([FromBody] RegionModel region)
        {
            if (region.RegionId != 0)
                return BadRequest();

            var result = await _regionRepository.AddAsync(region);
            return CreatedAtAction("GetRegion", new { id = result.RegionId }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRegionAsync([FromBody] RegionModel region)
        {
            if (region.RegionId == 0)
                return BadRequest();

            if (!await _regionRepository.ExistsAsync(region.RegionId))
                return NotFound();

            await _regionRepository.UpdateAsync(region.RegionId, region);
            return NoContent();
        }
    }
}
