using DomainLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.CustomerModel
{
    public class Customer
    {
        public Customer(int customerId, int regionId, string name, Address shippingAddress)
        {
            CustomerId = customerId;
            RegionId = regionId;
            Name = name;
            ShippingAddress = shippingAddress;
            Contacts = new List<Contact>();
        }

        public int CustomerId { get; set; }

        public int RegionId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? RegionName { get; set; }

        public Address ShippingAddress { get; set; }

        public List<Contact> Contacts { get; }
    }
}
