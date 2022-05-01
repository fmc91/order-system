using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderSystem.Controllers
{
    [Route("api/region")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRegionAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:int}/customer")]
        public async Task<IActionResult> GetCustomersByRegionAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:int}/order")]
        public async Task<IActionResult> GetOrdersByRegionAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegionAsync([FromBody] object region)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRegionAsync([FromBody] object region)
        {
            throw new NotImplementedException();
        }
    }
}
