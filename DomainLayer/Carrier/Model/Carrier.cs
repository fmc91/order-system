using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.CarrierModel
{
    public class Carrier
    {
        public Carrier(int carrierId, string name)
        {
            CarrierId = carrierId;
            Name = name;
        }

        public int CarrierId { get; set; }

        public string Name { get; set; }
    }
}
