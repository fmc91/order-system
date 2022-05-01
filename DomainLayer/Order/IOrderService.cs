using DomainLayer.OrderModel;

namespace DomainLayer
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<IList<Order>> GetAllOrdersAsync(int page, int itemsPerPage);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<IList<Order>> GetOrdersByCarrierAsync(int carrierId, int page, int itemsPerPage);
        Task<IList<Order>> GetOrdersByCustomerAsync(int customerId, int page, int itemsPerPage);
        Task<IList<Order>> GetOrdersByDistributionCentreAsync(int distributionCentreId, int page, int itemsPerPage);
        Task<IList<Order>> GetOrdersByProductAsync(int productId, int page, int itemsPerPage);
        Task UpdateOrderAsync(Order order);
    }
}