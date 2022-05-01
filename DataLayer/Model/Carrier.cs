using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Carrier
    {
        public Carrier(int carrierId, string name)
        {
            CarrierId = carrierId;
            Name = name;
            Orders = new HashSet<Order>();
        }

        public int CarrierId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; }
    }
}
