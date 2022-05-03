using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer;
using DomainLayer.CarrierModel;
using Microsoft.EntityFrameworkCore;
using EntityModel = DataLayer.Model;

namespace DomainLayer
{
    public class CarrierService : ICarrierService
    {
        private readonly OrderSystemContext _db;

        private readonly IMapper _mapper;

        public CarrierService(OrderSystemContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IList<Carrier>> GetAllCarriersAsync(int page, int itemsPerPage)
        {
            var carrierEntities = await _db.Carrier
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return _mapper.Map<List<Carrier>>(carrierEntities);
        }

        public async Task<Carrier> GetCarrierByIdAsync(int carrierId)
        {
            var carrierEntity = await _db.Carrier.FindAsync(carrierId) ??
                throw new EntityNotFoundException("Carrier", carrierId);

            return _mapper.Map<Carrier>(carrierEntity);
        }

        public async Task<Carrier> CreateCarrier(Carrier carrier)
        {
            if (carrier.CarrierId != 0)
                throw new InvalidOperationException("Entity primary key must be equal to zero to create a new entity.");

            var carrierEntity = _mapper.Map<EntityModel.Carrier>(carrier);
            _db.Carrier.Update(carrierEntity);

            await _db.SaveChangesAsync();

            return _mapper.Map<Carrier>(carrierEntity);
        }

        public async Task UpdateCarrier(Carrier carrier)
        {
            if (carrier.CarrierId == 0)
                throw new InvalidOperationException("Entity primary key must be non-zero to update an entity.");

            var carrierEntity = await _db.Carrier.FindAsync(carrier.CarrierId) ??
                throw new EntityNotFoundException("Carrier", carrier.CarrierId);

            _mapper.Map(carrier, carrierEntity);

            await _db.SaveChangesAsync();
        }
    }
}
