using DomainLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class CustomerModel
    {
        public CustomerModel(int customerId, int regionId, string name, AddressModel shippingAddress)
        {
            CustomerId = customerId;
            RegionId = regionId;
            Name = name;
            ShippingAddress = shippingAddress;
            Contacts = new List<ContactModel>();
        }

        public int CustomerId { get; set; }

        public int RegionId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? RegionName { get; set; }

        public AddressModel ShippingAddress { get; set; }

        public List<ContactModel> Contacts { get; }
    }
}
