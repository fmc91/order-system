
namespace DataLayer.Repositories
{
    public interface IOrderRepository
    {
        Task<IList<TModel>> GetAllAsync<TModel>(int page, int itemsPerPage);

        Task<IList<TModel>> GetByCarrierAsync<TModel>(int carrierId, int page, int itemsPerPage);

        Task<IList<TModel>> GetByCustomerAsync<TModel>(int customerId, int page, int itemsPerPage);

        Task<IList<TModel>> GetByDistributionCentreAsync<TModel>(int distributionCentreId, int page, int itemsPerPage);

        Task<IList<TModel>> GetByProductAsync<TModel>(int productId, int page, int itemsPerPage);

        Task<IList<TModel>> GetByRegionAsync<TModel>(int regionId, int page, int itemsPerPage);

        Task<bool> ExistsAsync(object id);

        Task<TModel> GetByIdAsync<TModel>(object id);

        Task<TModel> AddAsync<TModel>(TModel item);

        Task UpdateAsync<TModel>(object id, TModel item);

        Task RemoveAsync(object id);
    }
}