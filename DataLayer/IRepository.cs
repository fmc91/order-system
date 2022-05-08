
namespace DataLayer
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<bool> ExistsAsync(object id);

        Task<IList<TModel>> GetAllAsync<TModel>();

        Task<TModel> GetByIdAsync<TModel>(object id);

        Task<IList<TModel>> QueryAsync<TModel>(Func<IQueryable<TEntity>, IQueryable<TEntity>> query);

        Task<TModel> QuerySingleAsync<TModel>(Func<IQueryable<TEntity>, Task<TEntity>> query);

        Task<TModel?> QuerySingleOrDefaultAsync<TModel>(Func<IQueryable<TEntity>, Task<TEntity?>> query);

        Task<TModel> AddAsync<TModel>(TModel item);

        Task UpdateAsync<TModel>(object id, TModel item);

        Task RemoveAsync(object id);
    }
}