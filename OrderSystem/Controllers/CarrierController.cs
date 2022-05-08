using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLayer;
using DataLayer.Model;
using OrderSystem.Model;

namespace OrderSystem.Controllers
{
    [Route("api/carrier")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly IRepository<Carrier> _carrierRepository;

        private readonly IRepository<Order> _orderRepository;

        public CarrierController(RepositoryProvider repositoryProvider)
        {
            _carrierRepository = repositoryProvider.GetRepository<Carrier>();
            _orderRepository = repositoryProvider.GetRepository<Order>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarriersAsync(int page = 0, int itemsPerPage = 20)
        {
            var result = await _carrierRepository.QueryAsync<CarrierModel>(x => x
                .OrderBy(c => c.Name)
                .Paginate(page, itemsPerPage));

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCarrierAsync(int id)
        {
            if (!await _carrierRepository.ExistsAsync(id))
                return NotFound();

            var result = await _carrierRepository.GetByIdAsync<CarrierModel>(id);
            return Ok(result);
        }

        [HttpGet("{id:int}/order")]
        public async Task<IActionResult> GetOrdersByCarrierAsync(int id, int page = 0, int itemsPerPage = 20)
        {
            if (!await _carrierRepository.ExistsAsync(id))
                return NotFound();

            var result = await _orderRepository.QueryAsync<OrderModel>(x => x
                .Where(o => o.CarrierId == id)
                .Paginate(page, itemsPerPage));
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarrierAsync([FromBody] CarrierModel carrier)
        {
            if (carrier.CarrierId != 0)
                return BadRequest();

            var result = await _carrierRepository.AddAsync(carrier);
            return CreatedAtAction("GetCarrier", new { id = carrier.CarrierId }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarrierAsync([FromBody] CarrierModel carrier)
        {
            if (carrier.CarrierId == 0)
                return BadRequest();

            if (!await _carrierRepository.ExistsAsync(carrier.CarrierId))
                return NotFound();

            await _carrierRepository.UpdateAsync(carrier.CarrierId, carrier);
            return NoContent();
        }
    }
}
