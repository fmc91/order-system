using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.Model;

namespace DataLayer.Repositories
{
    public class RegionRepository : RepositoryBase<Region>, IRegionRepository
    {
        public RegionRepository(OrderSystemContext db, IMapper mapper) : base(db, mapper) { }

        public async Task<IList<TModel>> GetAllAsync<TModel>(int page, int itemsPerPage)
        {
            return await QueryAsync<TModel>(x => x
                .OrderBy(r => r.Name)
                .Paginate(page, itemsPerPage));
        }

        public async Task<IList<TModel>> GetByNameSearchAsync<TModel>(string query, int page, int itemsPerPage)
        {
            return await QueryAsync<TModel>(x => x
                .Where(r => r.Name.Contains(query))
                .OrderBy(r => r.Name)
                .Paginate(page, itemsPerPage));
        }
    }
}
