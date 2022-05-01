using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DomainLayer.OrderModel;
using EntityModel = DataLayer.Model;

namespace DomainLayer
{
    public class OrderService : IOrderService
    {
        private readonly OrderSystemContext _db;

        private readonly IMapper _mapper;

        public OrderService(OrderSystemContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IList<Order>> GetAllOrdersAsync(int page, int itemsPerPage)
        {
            var orderEntities = await _db.Order
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return _mapper.Map<List<Order>>(orderEntities);
        }

        public async Task<IList<Order>> GetOrdersByCustomerAsync(int customerId, int page, int itemsPerPage)
        {
            var orderEntities = await _db.Order
                .Where(x => x.CustomerId == customerId)
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return _mapper.Map<List<Order>>(orderEntities);
        }

        public async Task<IList<Order>> GetOrdersByCarrierAsync(int carrierId, int page, int itemsPerPage)
        {
            var orderEntities = await _db.Order
                .Where(x => x.CarrierId == carrierId)
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return _mapper.Map<List<Order>>(orderEntities);
        }

        public async Task<IList<Order>> GetOrdersByDistributionCentreAsync(int distributionCentreId, int page, int itemsPerPage)
        {
            var orderEntities = await _db.Order
                .Where(x => x.DistributionCentreId == distributionCentreId)
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return _mapper.Map<List<Order>>(orderEntities);
        }

        public async Task<IList<Order>> GetOrdersByProductAsync(int productId, int page, int itemsPerPage)
        {
            var orderEntities = await _db.Order
                .Where(x => x.OrderItems.Any(item => item.ProductId == productId))
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return _mapper.Map<List<Order>>(orderEntities);
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            var orderEntity = await _db.Product.FindAsync(orderId) ??
                throw new InvalidOperationException($"No record found in the Order table with id {orderId}.");

            return _mapper.Map<Order>(orderEntity);
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            if (order.OrderId != 0)
                throw new InvalidOperationException("Entity primary key must be equal to zero to create a new entity.");

            var orderEntity = _mapper.Map<EntityModel.Order>(order);

            _db.Order.Update(orderEntity);
            await _db.SaveChangesAsync();

            return _mapper.Map<Order>(orderEntity);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            if (order.OrderId == 0)
                throw new InvalidOperationException("Entity primary key must be non-zero to update an entity.");

            var orderEntity = _db.Order.Find(order.OrderId) ??
                throw new InvalidOperationException($"No record found in the Order table with id {order.OrderId}.");

            _mapper.Map(order, orderEntity);

            await _db.SaveChangesAsync();
        }
    }
}
