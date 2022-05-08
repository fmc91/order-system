using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLayer;
using DataLayer.Model;
using OrderSystem.Model;

namespace OrderSystem.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _customerRepository;

        private readonly IRepository<Order> _orderRepository;

        public CustomerController(RepositoryProvider repositoryProvider)
        {
            _customerRepository = repositoryProvider.GetRepository<Customer>();
            _orderRepository = repositoryProvider.GetRepository<Order>();
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync(int page = 0, int itemsPerPage = 20)
        {
            var result = await _customerRepository.QueryAsync<CustomerModel>(x => x
                .OrderBy(c => c.Name)
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage));

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetCustomersByNameSearchAsync(string query, int page = 0, int itemsPerPage = 20)
        {
            var result = await _customerRepository.QueryAsync<CustomerModel>(x => x
                .Where(c => c.Name.Contains(query))
                .OrderBy(c => c.Name)
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage));

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

            var result = await _orderRepository.QueryAsync<OrderModel>(x => x
                .Where(o => o.CustomerId == id)
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CustomerModel customer)
        {
            if (customer.CustomerId != 0)
                return BadRequest();

            var result = await _customerRepository.AddAsync(customer);
            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
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
