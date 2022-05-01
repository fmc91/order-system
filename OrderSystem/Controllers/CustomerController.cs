using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderSystem.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync(int page = 0, int itemsPerPage = 20)
        {
            throw new NotImplementedException();
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetCustomersByNameSearchAsync(string query)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:int}/order")]
        public async Task<IActionResult> GetOrdersByCustomerAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] object customer)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAsync([FromBody] object customer)
        {
            throw new NotImplementedException();
        }
    }
}
