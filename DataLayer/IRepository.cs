
namespace DataLayer
{
    public interface IRepository<TModel, TEntity> where TEntity : class
    {
        Task<bool> ExistsAsync(object id);

        Task<IList<TModel>> GetAllAsync();

        Task<TModel> GetByIdAsync(object id);

        Task<IList<TModel>> QueryAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> query);

        Task<TModel> QuerySingleAsync(Func<IQueryable<TEntity>, Task<TEntity>> query);

        Task<TModel?> QuerySingleOrDefaultAsync(Func<IQueryable<TEntity>, Task<TEntity?>> query);

        Task<TModel> AddAsync(TModel item);

        Task UpdateAsync(object id, TModel item);

        Task RemoveAsync(object id);
    }
}