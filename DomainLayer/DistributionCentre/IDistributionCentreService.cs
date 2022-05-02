using DomainLayer.DistributionCentreModel;

namespace DomainLayer
{
    public interface IDistributionCentreService
    {
        Task<DistributionCentre> CreateDistributionCentreAsync(DistributionCentre distributionCentre);
        Task<StockItem> CreateStockItemAsync(StockItem stockItem);
        Task<IList<DistributionCentre>> GetAllDistributionCentresAsync(int page, int itemsPerPage);
        Task<DistributionCentre> GetDistributionCentreByIdAsync(int distributionCentreId);
        Task<IList<DistributionCentre>> GetDistributionCentresByCountryCodeAsync(string countryCode, int page, int itemsPerPage);
        Task<IList<DistributionCentre>> GetDistributionCentresByNameSearchAsync(string query, int page, int itemsPerPage);
        Task<IList<StockItem>> GetStockItemsByDistributionCentreAsync(int distributionCentreId, int page, int itemsPerPage);
        Task<IList<StockItem>> GetStockItemsByProductAsync(int productId, int page, int itemsPerPage);
        Task UpdateDistributionCentreAsync(DistributionCentre distributionCentre);
        Task UpdateStockItemAsync(StockItem stockItem);
    }
}