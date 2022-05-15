using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLayer;
using DataLayer.Model;
using OrderSystem.Model;
using DataLayer.Repositories;

namespace OrderSystem.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        private readonly IOrderRepository _orderRepository;

        public CustomerController(ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomersAsync(int page = 0, int itemsPerPage = 20)
        {
            var result = await _customerRepository.GetAllAsync<CustomerModel>(page, itemsPerPage);

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetCustomersByNameSearchAsync(string query, int page = 0, int itemsPerPage = 20)
        {
            var result = await _customerRepository.GetByNameSearchAsync<CustomerModel>(query, page, itemsPerPage);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            if (!await _customerRepository.ExistsAsync(id))
                return NotFound();

            var result = _customerRepository.GetByIdAsync<CustomerModel>(id);
            return Ok(result);
        }

        [HttpGet("{id:int}/order")]
        public async Task<IActionResult> GetOrdersByCustomerAsync(int id, int page = 0, int itemsPerPage = 20)
        {
            if (!await _customerRepository.ExistsAsync(id))
                return NotFound();

            var result = await _orderRepository.GetByCustomerAsync<OrderModel>(id, page, itemsPerPage);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CustomerModel customer)
        {
            if (customer.CustomerId != 0)
                return BadRequest();

            var result = await _customerRepository.AddAsync(customer);
            return CreatedAtAction("GetCustomer", new { id = result.CustomerId }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAsync([FromBody] CustomerModel customer)
        {
            if (customer.CustomerId == 0)
                return BadRequest();

            if (!await _orderRepository.ExistsAsync(customer.CustomerId))
                return NotFound();

            await _customerRepository.UpdateAsync(customer.CustomerId, customer);
            return NoContent();
        }
    }
}
