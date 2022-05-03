using DomainLayer;
using DomainLayer.CustomerModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderSystem.Controllers
{
    [Route("api/region")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        private readonly IOrderService _orderService;

        public RegionController(ICustomerService customerService, IOrderService orderService)
        {
            _customerService = customerService;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync(int page, int itemsPerPage)
        {
            var result = await _customerService.GetAllRegionsAsync(page, itemsPerPage);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRegionAsync(int id)
        {
            try
            {
                var result = await _customerService.GetRegionByIdAsync(id);
                return Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { errorMessage = ex.Message });
            }
        }

        [HttpGet("{id:int}/customer")]
        public async Task<IActionResult> GetCustomersByRegionAsync(int id, int page, int itemsPerPage)
        {
            var result = await _customerService.GetCustomersByRegionAsync(id, page, itemsPerPage);
            return Ok(result);
        }

        [HttpGet("{id:int}/order")]
        public async Task<IActionResult> GetOrdersByRegionAsync(int id, int page, int itemsPerPage)
        {
            var result = await _orderService.GetOrdersByRegionAsync(id, page, itemsPerPage);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegionAsync([FromBody] Region region)
        {
            try
            {
                var result = await _customerService.CreateRegionAsync(region);
                return CreatedAtAction("GetRegion", new { id = result.RegionId }, result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { errorMessage = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRegionAsync([FromBody] Region region)
        {
            try
            {
                await _customerService.UpdateRegionAsync(region);
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
