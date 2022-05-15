using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.Model;

namespace DataLayer.Repositories
{
    public class StockItemRepository : RepositoryBase<StockItem>, IStockItemRepository
    {
        public StockItemRepository(OrderSystemContext db, IMapper mapper) : base(db, mapper) { }

        public async Task<IList<TModel>> GetByDistributionCentreAsync<TModel>(int distributionCentreId, int page, int itemsPerPage)
        {
            return await QueryAsync<TModel>(x => x
                .Where(i => i.DistributionCentreId == distributionCentreId)
                .OrderBy(i => i.Product.Name)
                .Paginate(page, itemsPerPage));
        }

        public async Task<IList<TModel>> GetByProductAsync<TModel>(int productId, int page, int itemsPerPage)
        {
            return await QueryAsync<TModel>(x => x
                .Where(i => i.ProductId == productId)
                .OrderBy(i => i.Product.Name)
                .Paginate(page, itemsPerPage));
        }
    }
}
