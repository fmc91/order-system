
namespace DataLayer.Repositories
{
    public interface ICarrierRepository
    {
        Task<IList<TModel>> GetAllAsync<TModel>(int page, int itemsPerPage);

        Task<IList<TModel>> GetByNameSearchAsync<TModel>(string query, int page, int itemsPerPage);

        Task<bool> ExistsAsync(object id);

        Task<TModel> GetByIdAsync<TModel>(object id);

        Task<TModel> AddAsync<TModel>(TModel item);

        Task UpdateAsync<TModel>(object id, TModel item);

        Task RemoveAsync(object id);
    }
}