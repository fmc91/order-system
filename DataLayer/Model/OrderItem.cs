using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class OrderItem
    {
        private Order? _order;

        private Product? _product;

        public OrderItem(int orderId, int productId, int quantity, decimal unitPrice)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public virtual Order Order
        {
            get => _order ??
                throw new InvalidOperationException($"Uninitialized property: {nameof(Order)}");
            set => _order = value;
        }

        public virtual Product Product
        {
            get => _product ??
                throw new InvalidOperationException($"Uninitialized property: {nameof(Product)}");
            set => _product = value;
        }
    }
}
