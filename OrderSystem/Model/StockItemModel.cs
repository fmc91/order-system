using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class StockItemModel
    {
        public StockItemModel(int distributionCentreId, int productId, int quantity)
        {
            DistributionCentreId = distributionCentreId;
            ProductId = productId;
            Quantity = quantity;
        }

        public int DistributionCentreId { get; set; }

        public int ProductId { get; set; }

        public string? DistributionCentreName { get; set; }

        public string? ProductName { get; set; }

        public int Quantity { get; set; }
    }
}
