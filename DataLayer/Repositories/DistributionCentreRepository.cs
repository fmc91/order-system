using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.Model;

namespace DataLayer.Repositories
{
    public class DistributionCentreRepository : RepositoryBase<DistributionCentre>, IDistributionCentreRepository
    {
        public DistributionCentreRepository(OrderSystemContext db, IMapper mapper) : base(db, mapper) { }

        public async Task<IList<TModel>> GetAllAsync<TModel>(int page, int itemsPerPage, int? countryId)
        {
            Expression<Func<DistributionCentre, bool>> whereCondition =
                countryId == null ?
                    c => true :
                    c => c.DistributionCentreAddress.Address.CountryId == countryId;

            return await QueryAsync<TModel>(x => x
                .Where(whereCondition)
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
