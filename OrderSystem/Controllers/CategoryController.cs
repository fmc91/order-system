using DomainLayer;
using DomainLayer.ProductModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderSystem.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IProductService _productService;

        public CategoryController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync(int page = 0, int itemsPerPage = 20)
        {
            var result = await _productService.GetAllCategoriesAsync(page, itemsPerPage);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetCategoriesByNameSearchAsync(string query, int page = 0, int itemsPerPage = 20)
        {
            var result = await _productService.GetCategoriesByNameSearchAsync(query, page, itemsPerPage);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryAsync(int id)
        {
            try
            {
                var result = await _productService.GetCategoryByIdAsync(id);
                return Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { errorMessage = ex.Message });
            }
        }

        [HttpGet("{id:int}/product")]
        public async Task<IActionResult> GetProductsByCategoryAsync(int id, int page = 0, int itemsPerPage = 20)
        {
            var result = await _productService.GetProductsByCategoryAsync(id, page, itemsPerPage);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] Category category)
        {
            try
            {
                var result = await _productService.CreateCategoryAysnc(category);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { errorMessage = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategoryAsync([FromBody] Category category)
        {
            try
            {
                await _productService.UpdateCategoryAsync(category);
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

        [HttpDelete("{int:id}")]
        public async Task<IActionResult> RemoveCategoryAsync(int id)
        {
            try
            {
                await _productService.RemoveCategoryAsync(id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { errorMessage = ex.Message });
            }
        }
    }
}
