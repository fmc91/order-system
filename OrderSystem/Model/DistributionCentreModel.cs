using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class DistributionCentreModel
    {
        public DistributionCentreModel(int distributionCentreId, string name, AddressModel address)
        {
            DistributionCentreId = distributionCentreId;
            Name = name;
            Address = address;
        }

        public int DistributionCentreId { get; set; }

        public string Name { get; set; }

        public AddressModel Address { get; set; }
    }
}
