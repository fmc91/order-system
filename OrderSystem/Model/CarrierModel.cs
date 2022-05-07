using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class CarrierModel
    {
        public CarrierModel(int carrierId, string name)
        {
            CarrierId = carrierId;
            Name = name;
        }

        public int CarrierId { get; set; }

        public string Name { get; set; }
    }
}
