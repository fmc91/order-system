using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLayer;
using DataLayer.Model;
using OrderSystem.Model;
using DataLayer.Repositories;

namespace OrderSystem.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IProductRepository _productRepository;

        public CategoryController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync(int page = 0, int itemsPerPage = 20)
        {
            var result = await _categoryRepository.GetAllAsync<CategoryModel>(page, itemsPerPage);

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetCategoriesByNameSearchAsync(string query, int page = 0, int itemsPerPage = 20)
        {
            var result = await _categoryRepository.GetByNameSearchAsync<CategoryModel>(query, page, itemsPerPage);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryAsync(int id)
        {
            if (!await _categoryRepository.ExistsAsync(id))
                return NotFound();

            var result = await _categoryRepository.GetByIdAsync<CategoryModel>(id);
            return Ok(result);
        }

        [HttpGet("{id:int}/product")]
        public async Task<IActionResult> GetProductsByCategoryAsync(int id, int page = 0, int itemsPerPage = 20)
        {
            var result = await _productRepository.GetByCategoryAsync<ProductModel>(id, page, itemsPerPage);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CategoryModel category)
        {
            if (category.CategoryId != 0)
                return BadRequest();

            var result = await _productRepository.AddAsync(category);
            return CreatedAtAction("GetCategory", new { id = result.CategoryId }, category);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategoryAsync([FromBody] CategoryModel category)
        {
            if (category.CategoryId == 0)
                return BadRequest();

            if (!await _categoryRepository.ExistsAsync(category.CategoryId))
                return NotFound();

            await _categoryRepository.UpdateAsync(category.CategoryId, category);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveCategoryAsync(int id)
        {
            if (!await _categoryRepository.ExistsAsync(id))
                return NotFound();

            await _categoryRepository.RemoveAsync(id);
            return NoContent();
        }
    }
}
