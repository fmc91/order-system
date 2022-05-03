using DomainLayer.CustomerModel;

namespace DomainLayer
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Region> CreateRegionAsync(Region region);
        Task<IList<Customer>> GetAllCustomersAsync(int page, int itemsPerPage);
        Task<IList<Region>> GetAllRegionsAsync(int page, int itemsPerPage);
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<IList<Customer>> GetCustomersByNameSearchAsync(string query, int page, int itemsPerPage);
        Task<IList<Customer>> GetCustomersByRegionAsync(int regionId, int page, int itemsPerPage);
        Task<Region> GetRegionByIdAsync(int regionId);
        Task UpdateCustomerAsync(Customer customer);
        Task UpdateRegionAsync(Region region);
    }
}