using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLayer;
using DataLayer.Model;
using OrderSystem.Model;
using DataLayer.Repositories;

namespace OrderSystem.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        private readonly IOrderRepository _orderRepository;

        private readonly IStockItemRepository _stockItemRepository;

        public ProductController(IProductRepository productRepository, IOrderRepository orderRepository, IStockItemRepository stockItemRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _stockItemRepository = stockItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync(int page = 0, int itemsPerPage = 20)
        {
            var result = await _productRepository.GetAllAsync<ProductModel>(page, itemsPerPage);

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetProductsByNameSearchAsync(string query, int page = 0, int itemsPerPage = 20)
        {
            var result = await _productRepository.GetByNameSearchAsync<ProductModel>(query, page, itemsPerPage);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            if (!await _productRepository.ExistsAsync(id))
                return NotFound();

            var result = await _productRepository.GetByIdAsync<ProductModel>(id);
            return Ok(result);
        }

        [HttpGet("{id:int}/order")]
        public async Task<IActionResult> GetOrdersByProductAsync(int id, int page = 0, int itemsPerPage = 20)
        {
            if (!await _productRepository.ExistsAsync(id))
                return NotFound();

            var result = await _orderRepository.GetByProductAsync<ProductModel>(id, page, itemsPerPage);

            return Ok(result);
        }

        [HttpGet("{id:int}/stock-item")]
        public async Task<IActionResult> GetStockItemsByProductAsync(int id, int page = 0, int itemsPerPage = 20)
        {
            if (!await _productRepository.ExistsAsync(id))
                return NotFound();

            var result = await _stockItemRepository.GetByProductAsync<ProductModel>(id, page, itemsPerPage);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] ProductModel product)
        {
            if (product.ProductId != 0)
                return BadRequest();

            var result = await _productRepository.AddAsync(product);
            return CreatedAtAction("GetProduct", new { id = result.ProductId }, result);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync([FromBody] ProductModel product)
        {
            if (product.ProductId == 0)
                return BadRequest();

            if (!await _productRepository.ExistsAsync(product.ProductId))
                return NotFound();

            await _productRepository.UpdateAsync(product.ProductId, product);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveProductAsync(int id)
        {
            if (!await _productRepository.ExistsAsync(id))
                return NotFound();

            await _productRepository.RemoveAsync(id);
            return NoContent();
        }
    }
}
