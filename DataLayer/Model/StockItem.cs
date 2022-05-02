using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class StockItem
    {
        private DistributionCentre? _distributionCentre;

        private Product? _product;

        public StockItem(int distributionCentreId, int productId, int quantity)
        {
            DistributionCentreId = distributionCentreId;
            ProductId = productId;
            Quantity = quantity;
        }

        public int DistributionCentreId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public virtual DistributionCentre DistributionCentre
        {
            get => _distributionCentre ??
                throw new InvalidOperationException($"Uninitialized property: {DistributionCentre}");
            set => _distributionCentre = value;
        }

        public virtual Product Product
        {
            get => _product ??
                throw new InvalidOperationException($"Uninitialized property: {Product}");
            set => _product = value;
        }
    }
}
