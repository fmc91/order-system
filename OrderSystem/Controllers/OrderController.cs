using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLayer;
using DataLayer.Model;
using OrderSystem.Model;

namespace OrderSystem.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderController(RepositoryProvider repositoryProvider)
        {
            _orderRepository = repositoryProvider.GetRepository<Order>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrdersAsync(int page = 0, int itemsPerPage = 20)
        {
            var result = await _orderRepository.QueryAsync<OrderModel>(x => x
                .Paginate(page, itemsPerPage));

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOrderAsync(int id)
        {
            if (!await _orderRepository.ExistsAsync(id))
                return NotFound();

            var result = _orderRepository.GetByIdAsync<OrderModel>(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] OrderModel order)
        {
            if (order.OrderId != 0)
                return BadRequest();

            var result = await _orderRepository.AddAsync(order);
            return CreatedAtAction("GetOrder", new { id = result.OrderId }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderAsync([FromBody] OrderModel order)
        {
            if (order.OrderId == 0)
                return BadRequest();

            if (!await _orderRepository.ExistsAsync(order.OrderId))
                return NotFound();

            await _orderRepository.UpdateAsync(order.OrderId, order);
            return NoContent();
        }
    }
}
