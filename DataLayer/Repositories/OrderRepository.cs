using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.Model;

namespace DataLayer.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderSystemContext db, IMapper mapper) : base(db, mapper) { }

        public async Task<IList<TModel>> GetAllAsync<TModel>(int page, int itemsPerPage)
        {
            return await QueryAsync<TModel>(x => x
                .OrderBy(o => o.OrderPlaced)
                .Paginate(page, itemsPerPage));
        }

        public async Task<IList<TModel>> GetByProductAsync<TModel>(int productId, int page, int itemsPerPage)
        {
            return await QueryAsync<TModel>(x => x
                .Where(o => o.OrderItems.Any(p => p.ProductId == productId))
                .OrderBy(o => o.OrderPlaced)
                .Paginate(page, itemsPerPage));
        }

        public async Task<IList<TModel>> GetByDistributionCentreAsync<TModel>(int distributionCentreId, int page, int itemsPerPage)
        {
            return await QueryAsync<TModel>(x => x
                .Where(o => o.DistributionCentreId == distributionCentreId)
                .OrderBy(o => o.OrderPlaced)
                .Paginate(page, itemsPerPage));
        }

        public async Task<IList<TModel>> GetByCustomerAsync<TModel>(int customerId, int page, int itemsPerPage)
        {
            return await QueryAsync<TModel>(x => x
                .Where(o => o.CustomerId == customerId)
                .OrderBy(o => o.OrderPlaced)
                .Paginate(page, itemsPerPage));
        }

        public async Task<IList<TModel>> GetByRegionAsync<TModel>(int regionId, int page, int itemsPerPage)
        {
            return await QueryAsync<TModel>(x => x
                .Where(o => o.Customer.RegionId == regionId)
                .OrderBy(o => o.OrderPlaced)
                .Paginate(page, itemsPerPage));
        }

        public async Task<IList<TModel>> GetByCarrierAsync<TModel>(int carrierId, int page, int itemsPerPage)
        {
            return await QueryAsync<TModel>(x => x
                .Where(o => o.CarrierId == carrierId)
                .OrderBy(o => o.OrderPlaced)
                .Paginate(page, itemsPerPage));
        }
    }
}
