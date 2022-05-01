using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Customer
    {
        private ShippingAddress? _shippingAddress;

        private Region? _region;

        public Customer(int customerId, int regionId, string name)
        {
            CustomerId = customerId;
            RegionId = regionId;
            Name = name;
            Orders = new HashSet<Order>();
            Contacts = new HashSet<Contact>();
        }

        public int CustomerId { get; set; }

        public int RegionId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public virtual ShippingAddress ShippingAddress
        {
            get => _shippingAddress ??
                throw new InvalidOperationException($"Uninitialized property: {nameof(ShippingAddress)}");
            set => _shippingAddress = value;
        }

        public virtual Region Region
        {
            get => _region ??
                throw new InvalidOperationException($"Uninitialized property: {nameof(Region)}");
            set => _region = value;
        }

        public virtual ICollection<Order> Orders { get; }

        public virtual ICollection<Contact> Contacts { get; }
    }
}
