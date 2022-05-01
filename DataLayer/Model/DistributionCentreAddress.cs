using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class DistributionCentreAddress
    {
        private DistributionCentre? _distributionCentre;

        private Address? _address;

        public DistributionCentreAddress(int distributionCentreId, int addressId)
        {
            DistributionCentreId = distributionCentreId;
            AddressId = addressId;
        }

        public int DistributionCentreId { get; set; }

        public int AddressId { get; set; }

        public virtual DistributionCentre DistributionCentre
        {
            get => _distributionCentre ??
                throw new InvalidOperationException($"Uninitialized property: {nameof(DistributionCentre)}");
            set => _distributionCentre = value;
        }

        public virtual Address Address
        {
            get => _address ??
                throw new InvalidOperationException($"Uninitialized property: {nameof(Address)}");
            set => _address = value;
        }
    }
}
