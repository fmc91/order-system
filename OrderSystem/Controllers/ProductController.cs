using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLayer;
using DataLayer.Model;
using OrderSystem.Model;

namespace OrderSystem.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;

        private readonly IRepository<Order> _orderRepository;

        private readonly IRepository<StockItem> _stockItemRepository;

        public ProductController(RepositoryProvider repositoryProvider)
        {
            _productRepository = repositoryProvider.GetRepository<Product>();
            _orderRepository = repositoryProvider.GetRepository<Order>();
            _stockItemRepository = repositoryProvider.GetRepository<StockItem>();
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync(int page = 0, int itemsPerPage = 20)
        {
            var result = await _productRepository.QueryAsync<ProductModel>(x => x
                .OrderBy(p => p.Name)
                .Paginate(page, itemsPerPage));

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetProductsByNameSearchAsync(string query, int page = 0, int itemsPerPage = 20)
        {
            var result = await _productRepository.QueryAsync<ProductModel>(x => x
                .Where(p => p.Name.Contains(query))
                .OrderBy(p => p.Name)
                .Paginate(page, itemsPerPage));

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

            var result = await _orderRepository.QueryAsync<ProductModel>(x => x
                .Where(o => o.OrderItems.Any(p => p.ProductId == id))
                .Paginate(page, itemsPerPage));

            return Ok(result);
        }

        [HttpGet("{id:int}/stock-item")]
        public async Task<IActionResult> GetStockItemsByProductAsync(int id, int page = 0, int itemsPerPage = 20)
        {
            if (!await _productRepository.ExistsAsync(id))
                return NotFound();

            var result = await _stockItemRepository.QueryAsync<ProductModel>(x => x
                .Where(i => i.ProductId == id)
                .Paginate(page, itemsPerPage));

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
