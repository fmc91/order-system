
namespace DataLayer.Repositories
{
    public interface IStockItemRepository
    {
        Task<IList<TModel>> GetByDistributionCentreAsync<TModel>(int distributionCentreId, int page, int itemsPerPage);

        Task<IList<TModel>> GetByProductAsync<TModel>(int productId, int page, int itemsPerPage);

        Task<bool> ExistsAsync(object id);

        Task<TModel> GetByIdAsync<TModel>(object id);

        Task<TModel> AddAsync<TModel>(TModel item);

        Task UpdateAsync<TModel>(object id, TModel item);

        Task RemoveAsync(object id);
    }
}