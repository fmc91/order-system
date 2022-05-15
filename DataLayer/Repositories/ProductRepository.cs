using AutoMapper;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(OrderSystemContext db, IMapper mapper) : base(db, mapper) { }

        public async Task<IList<TModel>> GetAllAsync<TModel>(int page, int itemsPerPage)
        {
            return await QueryAsync<TModel>(x => x
                .OrderBy(p => p.Name)
                .Paginate(page, itemsPerPage));
        }

        public async Task<IList<TModel>> GetByNameSearchAsync<TModel>(string query, int page = 0, int itemsPerPage = 20)
        {
            return await QueryAsync<TModel>(x => x
                .Where(p => p.Name.Contains(query))
                .OrderBy(p => p.Name)
                .Paginate(page, itemsPerPage));
        }

        public async Task<IList<TModel>> GetByCategoryAsync<TModel>(int categoryId, int page = 0, int itemsPerPage = 20)
        {
            return await QueryAsync<TModel>(x => x
                .Where(p => p.CategoryId == categoryId)
                .OrderBy(p => p.Name)
                .Paginate(page, itemsPerPage));
        }
    }
}
