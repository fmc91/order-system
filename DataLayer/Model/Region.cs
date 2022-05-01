using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Region
    {
        public Region(int regionId, string name)
        {
            RegionId = regionId;
            Name = name;
            Customers = new HashSet<Customer>();
        }

        public int RegionId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; }
    }
}
