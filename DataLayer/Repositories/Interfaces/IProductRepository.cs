
namespace DataLayer.Repositories
{
    public interface IProductRepository
    {
        Task<IList<TModel>> GetAllAsync<TModel>(int page, int itemsPerPage);

        Task<IList<TModel>> GetByCategoryAsync<TModel>(int categoryId, int page = 0, int itemsPerPage = 20);

        Task<IList<TModel>> GetByNameSearchAsync<TModel>(string query, int page = 0, int itemsPerPage = 20);

        Task<bool> ExistsAsync(object id);

        Task<TModel> GetByIdAsync<TModel>(object id);

        Task<TModel> AddAsync<TModel>(TModel item);

        Task UpdateAsync<TModel>(object id, TModel item);

        Task RemoveAsync(object id);
    }
}