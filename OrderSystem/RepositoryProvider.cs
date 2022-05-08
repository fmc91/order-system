using DataLayer;

namespace OrderSystem
{
    public class RepositoryProvider
    {
        private readonly IServiceProvider _services;

        public RepositoryProvider(IServiceProvider services)
        {
            _services = services;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return _services.GetRequiredService<IRepository<TEntity>>();
        }
    }
}
