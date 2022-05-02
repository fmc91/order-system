using DomainLayer;
using DomainLayer.CustomerModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderSystem.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        private readonly IOrderService _orderService;

        public CustomerController(ICustomerService customerService, IOrderService orderService)
        {
            _customerService = customerService;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync(int page = 0, int itemsPerPage = 20)
        {
            var result = await _customerService.GetAllCustomersAsync(page, itemsPerPage);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetCustomersByNameSearchAsync(string query, int page = 0, int itemsPerPage = 20)
        {
            var result = await _customerService.GetCustomersByNameSearchAsync(query, page, itemsPerPage);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            try
            {
                var result = await _customerService.GetCustomerByIdAsync(id);
                return Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { errorMessage = ex.Message });
            }
        }

        [HttpGet("{id:int}/order")]
        public async Task<IActionResult> GetOrdersByCustomerAsync(int id, int page = 0, int itemsPerPage = 20)
        {
            var result = await _orderService.GetOrdersByCustomerAsync(id, page, itemsPerPage);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] Customer customer)
        {
            try
            {
                var result = await _customerService.CreateCustomerAsync(customer);
                return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { errorMessage = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAsync([FromBody] Customer customer)
        {
            try
            {
                await _customerService.UpdateCustomerAsync(customer);
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
