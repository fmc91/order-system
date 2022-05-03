using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.CustomerModel
{
    public class Region
    {
        public Region(int regionId, string name)
        {
            RegionId = regionId;
            Name = name;
        }

        public int RegionId { get; set; }

        public string Name { get; set; }
    }
}
