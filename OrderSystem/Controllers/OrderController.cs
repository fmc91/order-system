using DomainLayer;
using DomainLayer.OrderModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderSystem.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrdersAsync(int page = 0, int itemsPerPage = 20)
        {
            var result = await _orderService.GetAllOrdersAsync(page, itemsPerPage);
            return Ok(result);
        }

        [HttpGet("{id:int")]
        public async Task<IActionResult> GetOrderAsync(int id)
        {
            try
            {
                var result = await _orderService.GetOrderByIdAsync(id);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { errorMessage = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] Order order)
        {
            if (order.OrderId != 0)
                return BadRequest(new { errorMessage = "Entity primary key must be equal to zero to create a new entity." });

            var result = await _orderService.CreateOrderAsync(order);

            return CreatedAtAction("GetOrder", new { id = result.OrderId }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderAsync([FromBody] Order order)
        {
            if (order.OrderId != 0)
                return BadRequest(new { errorMessage = "Entity primary key must be non-zero to update an entity." });

            try
            {
                await _orderService.UpdateOrderAsync(order);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { errorMessage = ex.Message });
            }
        }
    }
}
