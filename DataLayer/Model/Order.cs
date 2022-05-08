using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Order
    {
        private Carrier? _carrier;

        private Customer? _customer;

        public DistributionCentre? _distributionCentre;

        public Order(int orderId, int carrierId, int customerId, int distributionCentreId)
        {
            OrderId = orderId;
            CarrierId = carrierId;
            CustomerId = customerId;
            DistributionCentreId = distributionCentreId;
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }

        public int CarrierId { get; set; }

        public int CustomerId { get; set; }

        public int DistributionCentreId { get; set; }

        [Column(TypeName = "money")]
        public decimal ShippingCost { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime OrderPlaced { get; set; }

        public virtual Carrier Carrier
        {
            get => _carrier ??
                throw new InvalidOperationException($"Uninitialized property: {nameof(Carrier)}");
            set => _carrier = value;
        }

        public virtual Customer Customer
        {
            get => _customer ??
                throw new InvalidOperationException($"Uninitialized property: {nameof(Customer)}");
            set => _customer = value;
        }

        public virtual DistributionCentre DistributionCentre
        {
            get => _distributionCentre ??
                throw new InvalidOperationException($"Uninitialized property: {nameof(DistributionCentre)}");
            set => _distributionCentre = value;
        }

        public virtual ICollection<OrderItem> OrderItems { get; }
    }
}
