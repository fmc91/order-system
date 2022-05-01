using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class ShippingAddress
    {
        private Customer? _customer;

        private Address? _address;

        public ShippingAddress(int customerId, int addressId)
        {
            CustomerId = customerId;
            AddressId = addressId;
        }

        public int CustomerId { get; set; }

        public int AddressId { get; set; }

        public virtual Customer Customer
        {
            get => _customer ??
                throw new InvalidOperationException($"Uninitialized property: {nameof(Customer)}");
            set => _customer = value;
        }

        public virtual Address Address
        {
            get => _address ??
                throw new InvalidOperationException($"Uninitialized property: {nameof(Address)}");
            set => _address = value;
        }
    }
}
