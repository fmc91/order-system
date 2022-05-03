using DomainLayer.CarrierModel;

namespace DomainLayer
{
    public interface ICarrierService
    {
        Task<Carrier> CreateCarrier(Carrier carrier);
        Task<IList<Carrier>> GetAllCarriers(int page, int itemsPerPage);
        Task<Carrier> GetCarrierById(int carrierId);
        Task UpdateCarrier(Carrier carrier);
    }
}