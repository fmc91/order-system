using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class RegionModel
    {
        public RegionModel(int regionId, string name)
        {
            RegionId = regionId;
            Name = name;
        }

        public int RegionId { get; set; }

        public string Name { get; set; }
    }
}
