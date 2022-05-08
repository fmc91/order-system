using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace OrderSystem.Model
{
    public class OrderModel
    {
        public OrderModel()
        {
            Items = new List<OrderItem>();
        }

        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int DistributionCentreId { get; set; }

        public int CarrierId { get; set; }

        public string? CustomerName { get; set; }

        public AddressModel? CustomerAddress { get; set; }

        public string? DistributionCentreName { get; set; }

        public string? CarrierName { get; set; }

        public decimal ShippingCost { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime OrderPlaced { get; set; }

        public List<OrderItem> Items { get; }

        public decimal Subtotal => Items.Sum(x => x.ItemTotal);

        public decimal TotalCost => Subtotal + ShippingCost;
    }
}
