using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.Model;

namespace DataLayer.Repositories
{
    public class CarrierRepository : RepositoryBase<Carrier>, ICarrierRepository
    {
        public CarrierRepository(OrderSystemContext db, IMapper mapper) : base(db, mapper) { }

        public async Task<IList<TModel>> GetAllAsync<TModel>(int page, int itemsPerPage)
        {
            return await QueryAsync<TModel>(x => x
                .OrderBy(c => c.Name)
                .Paginate(page, itemsPerPage));
        }

        public async Task<IList<TModel>> GetByNameSearchAsync<TModel>(string query, int page, int itemsPerPage)
        {
            return await QueryAsync<TModel>(x => x
                .Where(c => c.Name.Contains(query))
                .OrderBy(c => c.Name)
                .Paginate(page, itemsPerPage));
        }
    }
}
