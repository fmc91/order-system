using DomainLayer;
using DomainLayer.CarrierModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderSystem.Controllers
{
    [Route("api/carrier")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly ICarrierService _carrierService;

        private readonly IOrderService _orderService;

        public CarrierController(ICarrierService carrierService, IOrderService orderService)
        {
            _carrierService = carrierService;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarriersAsync(int page = 0, int itemsPerPage = 20)
        {
            var result = await _carrierService.GetAllCarriersAsync(page, itemsPerPage);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCarrierAsync(int id)
        {
            try
            {
                var result = await _carrierService.GetCarrierByIdAsync(id);
                return Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { errorMessage = ex.Message });
            }
        }

        [HttpGet("{id:int}/order")]
        public async Task<IActionResult> GetOrdersByCarrierAsync(int id, int page = 0, int itemsPerPage = 20)
        {
            var result = await _orderService.GetOrdersByCarrierAsync(id, page, itemsPerPage);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarrierAsync([FromBody] Carrier carrier)
        {
            try
            {
                var result = await _carrierService.CreateCarrier(carrier);
                return CreatedAtAction("GetCarrier", new { id = result.CarrierId }, result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { errorMessage = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarrierAsync([FromBody] Carrier carrier)
        {
            try
            {
                await _carrierService.UpdateCarrier(carrier);
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
