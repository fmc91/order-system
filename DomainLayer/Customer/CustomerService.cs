using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DataLayer;
using DomainLayer.CustomerModel;
using EntityModel = DataLayer.Model;

namespace DomainLayer
{
    public class CustomerService : ICustomerService
    {
        private readonly OrderSystemContext _db;

        private readonly IMapper _mapper;

        public CustomerService(OrderSystemContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IList<Customer>> GetAllCustomersAsync(int page, int itemsPerPage)
        {
            var customerEntities = await _db.Customer
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return _mapper.Map<List<Customer>>(customerEntities);
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            var customerEntity = await _db.Customer.FindAsync(customerId) ??
                throw new EntityNotFoundException("Customer", customerId);

            return _mapper.Map<Customer>(customerEntity);
        }

        public async Task<IList<Customer>> GetCustomersByRegionAsync(int regionId, int page, int itemsPerPage)
        {
            var customerEntities = await _db.Customer
                .Where(x => x.RegionId == regionId)
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return _mapper.Map<List<Customer>>(customerEntities);
        }

        public async Task<IList<Customer>> GetCustomersByNameSearchAsync(string query, int page, int itemsPerPage)
        {
            var customerEntities = await _db.Customer
                .Where(x => x.Name.Contains(query))
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return _mapper.Map<List<Customer>>(customerEntities);
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            if (customer.CustomerId != 0)
                throw new InvalidOperationException("Entity primary key must be equal to zero to create a new entity.");

            var customerEntity = _mapper.Map<EntityModel.Customer>(customer);

            _db.Customer.Update(customerEntity);
            await _db.SaveChangesAsync();

            return _mapper.Map<Customer>(customerEntity);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            if (customer.CustomerId == 0)
                throw new InvalidOperationException("Entity primary key must be non-zero to update an entity.");

            var customerEntity = _db.Customer.Find(customer.CustomerId) ??
                throw new EntityNotFoundException("Customer", customer.CustomerId);

            _mapper.Map(customer, customerEntity);

            await _db.SaveChangesAsync();
        }

        public async Task<IList<Region>> GetAllRegionsAsync(int page, int itemsPerPage)
        {
            var regionEntities = await _db.Region
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return _mapper.Map<List<Region>>(regionEntities);
        }

        public async Task<Region> GetRegionByIdAsync(int regionId)
        {
            var regionEntity = await _db.Region.FindAsync(regionId) ??
                throw new EntityNotFoundException("Region", regionId);

            return _mapper.Map<Region>(regionEntity);
        }

        public async Task UpdateRegionAsync(Region region)
        {
            if (region.RegionId == 0)
                throw new InvalidOperationException("Entity primary key must be non-zero to update an entity.");

            var regionEntity = await _db.Region.FindAsync(region.RegionId) ??
                throw new EntityNotFoundException("Region", region.RegionId);

            _mapper.Map(region, regionEntity);
            await _db.SaveChangesAsync();
        }

        public async Task<Region> CreateRegionAsync(Region region)
        {
            if (region.RegionId != 0)
                throw new InvalidOperationException("Entity primary key must be equal to zero to create a new entity.");

            var regionEntity = _mapper.Map<EntityModel.Region>(region);
            
            _db.Region.Update(regionEntity);
            await _db.SaveChangesAsync();

            return _mapper.Map<Region>(regionEntity);
        }
    }
}
