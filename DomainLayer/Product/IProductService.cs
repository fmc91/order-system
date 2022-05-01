using DomainLayer.ProductModel;

namespace DomainLayer
{
    public interface IProductService
    {
        Task<Category> CreateCategory(Category category);
        Task<Product> CreateProductAsync(Product product);
        Task<IList<Category>> GetAllCategoriesAsync(int page, int itemsPerPage);
        Task<IList<Product>> GetAllProductsAsync(int page, int itemsPerPage);
        Task<IList<Category>> GetCategoriesByNameSearchAsync(string query);
        Task<Category> GetCategoryByIdAsync(int categoryId);
        Task<Product> GetProductByIdAsync(int productId);
        Task<IList<Product>> GetProductsByCategoryId(int categoryId);
        Task<IList<Product>> GetProductsByNameSearch(string query);
        Task RemoveProductAsync(int id);
        Task UpdateCategory(Category category);
        Task UpdateProductAsync(Product product);
    }
}