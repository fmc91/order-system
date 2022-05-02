using DomainLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DistributionCentreModel
{
    public class DistributionCentre
    {
        public DistributionCentre(int distributionCentreId, string name, Address address)
        {
            DistributionCentreId = distributionCentreId;
            Name = name;
            Address = address;
        }

        public int DistributionCentreId { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }
    }
}
