using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DomainLayer.DistributionCentreModel;
using DomainLayer.Common;
using EntityModel = DataLayer.Model;

namespace DomainLayer
{
    public class DistributionCentreService
    {
        private readonly OrderSystemContext _db;

        private readonly IMapper _mapper;

        public DistributionCentreService(OrderSystemContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IList<DistributionCentre>> GetAllDistributionCentresAsync(int page, int itemsPerPage)
        {
            var dcEntities = await _db.DistributionCentre
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return _mapper.Map<List<DistributionCentre>>(dcEntities);
        }

        public async Task<DistributionCentre> GetDistributionCentreByIdAsync(int distributionCentreId)
        {
            var dcEntity = await _db.DistributionCentre.FindAsync(distributionCentreId) ??
                throw new EntityNotFoundException("DistributionCentre", distributionCentreId);

            return _mapper.Map<DistributionCentre>(dcEntity);
        }

        public async Task<IList<DistributionCentre>> GetDistributionCentresByNameSearchAsync(string query, int page, int itemsPerPage)
        {
            var dcEntities = await _db.DistributionCentre
                .Where(x => x.Name.Contains(query))
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return _mapper.Map<List<DistributionCentre>>(dcEntities);
        }

        public async Task<IList<DistributionCentre>> GetDistributionCentresByCountryCodeAsync(string countryCode, int page, int itemsPerPage)
        {
            var dcEntities = await _db.DistributionCentre
                .Where(x => x.DistributionCentreAddress.Address.Country.CountryCode == countryCode)
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return _mapper.Map<List<DistributionCentre>>(dcEntities);
        }

        public async Task<DistributionCentre> CreateDistributionCentreAsync(DistributionCentre distributionCentre)
        {
            if (distributionCentre.DistributionCentreId != 0)
                throw new InvalidOperationException("Entity primary key must be equal to zero to create a new entity.");

            var dcEntity = _mapper.Map<EntityModel.DistributionCentre>(distributionCentre);

            _db.DistributionCentre.Update(dcEntity);
            await _db.SaveChangesAsync();

            return _mapper.Map<DistributionCentre>(dcEntity);
        }

        public async Task UpdateDistributionCentreAsync(DistributionCentre distributionCentre)
        {
            if (distributionCentre.DistributionCentreId == 0)
                throw new InvalidOperationException("Entity primary key must be non-zero to update an entity.");

            var dcEntity = _db.Customer.Find(distributionCentre.DistributionCentreId) ??
                throw new EntityNotFoundException("DistributionCentre", distributionCentre.DistributionCentreId);

            _mapper.Map(distributionCentre, dcEntity);

            await _db.SaveChangesAsync();
        }

        public async Task<IList<StockItem>> GetStockItemsByDistributionCentreAsync(int distributionCentreId, int page, int itemsPerPage)
        {
            var stockItemEntities = await _db.StockItem
                .Where(x => x.DistributionCentreId == distributionCentreId)
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return _mapper.Map<List<StockItem>>(stockItemEntities);
        }

        public async Task<IList<StockItem>> GetStockItemsByProductAsync(int productId, int page, int itemsPerPage)
        {
            var stockItemEntities = await _db.StockItem
                .Where(x => x.ProductId == productId)
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return _mapper.Map<List<StockItem>>(stockItemEntities);
        }

        public async Task<StockItem> CreateStockItemAsync(StockItem stockItem)
        {
            if (_db.StockItem.Any(x => x.ProductId == stockItem.ProductId && x.DistributionCentreId == stockItem.DistributionCentreId))
                throw new InvalidOperationException("An entity with the given primary key already exists in the StockItem table.");

            var stockItemEntity = _mapper.Map<EntityModel.StockItem>(stockItem);

            _db.StockItem.Update(stockItemEntity);
            await _db.SaveChangesAsync();

            return _mapper.Map<StockItem>(stockItemEntity);
        }

        public async Task UpdateStockItemAsync(StockItem stockItem)
        {
            if (stockItem.ProductId == 0 || stockItem.DistributionCentreId == 0)
                throw new InvalidOperationException("Entity primary key must be non-zero to update an entity.");

            var stockItemEntity = _db.StockItem.Find(new { stockItem.ProductId, stockItem.DistributionCentreId }) ??
                throw new EntityNotFoundException("DistributionCentre", new { stockItem.ProductId, stockItem.DistributionCentreId });

            _mapper.Map(stockItem, stockItemEntity);

            await _db.SaveChangesAsync();
        }
    }
}
