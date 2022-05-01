using DomainLayer;
using DomainLayer.ProductModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderSystem.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        private readonly IOrderService _orderService;

        public ProductController(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync(int page = 0, int itemsPerPage = 20)
        {
            var result = await _productService.GetAllProductsAsync(page, itemsPerPage);

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetProductsByNameSearchAsync(string query, int page = 0, int itemsPerPage = 20)
        {
            var result = await _productService.GetProductsByNameSearchAsync(query, page, itemsPerPage);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            try
            {
                var result = await _productService.GetProductByIdAsync(id);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { errorMessage = ex.Message });
            }
        }

        [HttpGet("{id:int}/order")]
        public async Task<IActionResult> GetOrdersByProductAsync(int id, int page = 0, int itemsPerPage = 20)
        {
            var result = await _orderService.GetOrdersByProductAsync(id, page, itemsPerPage);
            return Ok(result);
        }

        [HttpGet("{id:int}/stock-item")]
        public async Task<IActionResult> GetStockItemsByProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] Product product)
        {
            try
            {
                var result = await _productService.CreateProductAsync(product);
                return CreatedAtAction("GetProduct", new { id = result.ProductId }, result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { errorMessage = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync([FromBody] Product product)
        {
            try
            {
                await _productService.UpdateProductAsync(product);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { errorMessage = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveProductAsync(int id)
        {
            try
            {
                await _productService.RemoveProductAsync(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { errorMessage = ex.Message });
            }
        }
    }
}
