using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderSystem.Controllers
{
    [Route("api/carrier")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCarriersAsync(int page = 0, int itemsPerPage = 20)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{int:id}")]
        public async Task<IActionResult> GetCarrierAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{int:id}/order")]
        public async Task<IActionResult> GetOrdersByCarrierAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarrierAsync([FromBody] object carrier)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarrierAsync([FromBody] object carrier)
        {
            throw new NotImplementedException();
        }
    }
}
