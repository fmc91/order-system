using DomainLayer.CarrierModel;

namespace DomainLayer
{
    public interface ICarrierService
    {
        Task<Carrier> CreateCarrier(Carrier carrier);
        Task<IList<Carrier>> GetAllCarriersAsync(int page, int itemsPerPage);
        Task<Carrier> GetCarrierByIdAsync(int carrierId);
        Task UpdateCarrier(Carrier carrier);
    }
}