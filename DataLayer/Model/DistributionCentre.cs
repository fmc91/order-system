using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class DistributionCentre
    {
        private DistributionCentreAddress? _distributionCentreAddress;

        public DistributionCentre(int distributionCentreId, string name)
        {
            DistributionCentreId = distributionCentreId;
            Name = name;
            StockItems = new HashSet<StockItem>();
            Orders = new HashSet<Order>();
        }

        public int DistributionCentreId { get; set; }

        public string Name { get; set; }

        public virtual DistributionCentreAddress DistributionCentreAddress
        {
            get => _distributionCentreAddress ??
                throw new InvalidOperationException($"Uninitialized property: {nameof(DistributionCentreAddress)}");
            set => _distributionCentreAddress = value;
        }

        public virtual ICollection<StockItem> StockItems { get; }

        public virtual ICollection<Order> Orders { get; }
    }
}
