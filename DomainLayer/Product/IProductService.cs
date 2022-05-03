using DomainLayer.ProductModel;

namespace DomainLayer
{
    public interface IProductService
    {
        Task<IList<Product>> GetAllProductsAsync(int page, int itemsPerPage);

        Task<Product> GetProductByIdAsync(int productId);

        Task<IList<Product>> GetProductsByCategoryAsync(int categoryId, int page, int itemsPerPage);

        Task<IList<Product>> GetProductsByNameSearchAsync(string query, int page, int itemsPerPage);

        Task<Product> CreateProductAsync(Product product);

        Task UpdateProductAsync(Product product);

        Task RemoveProductAsync(int id);

        Task<IList<Category>> GetAllCategoriesAsync(int page, int itemsPerPage);

        Task<Category> GetCategoryByIdAsync(int categoryId);

        Task<IList<Category>> GetCategoriesByNameSearchAsync(string query, int page, int itemsPerPage);

        Task<Category> CreateCategoryAysnc(Category category);

        Task UpdateCategoryAsync(Category category);
        Task RemoveCategoryAsync(int id);
    }
}