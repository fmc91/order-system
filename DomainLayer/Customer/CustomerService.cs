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
    }
}
