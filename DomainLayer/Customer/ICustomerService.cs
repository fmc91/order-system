using DomainLayer.CustomerModel;

namespace DomainLayer
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<IList<Customer>> GetAllCustomersAsync(int page, int itemsPerPage);
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<IList<Customer>> GetCustomersByNameSearchAsync(string query, int page, int itemsPerPage);
        Task<IList<Customer>> GetCustomersByRegionAsync(int regionId, int page, int itemsPerPage);
        Task UpdateCustomerAsync(Customer customer);
    }
}