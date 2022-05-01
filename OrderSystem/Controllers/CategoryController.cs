using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderSystem.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync(int page = 0, int itemsPerPage = 20)
        {
            throw new NotImplementedException();
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetCategoriesByNameSearchAsync(string query)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:int}/product")]
        public async Task<IActionResult> GetProductsByCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] object category)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategoryAsync([FromBody] object category)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{int:id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
