using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Country
    {
        public Country(int countryId, string countryCode, string name)
        {
            CountryId = countryId;
            CountryCode = countryCode;
            Name = name;
        }

        public int CountryId { get; set; }

        public string CountryCode { get; set; }

        public string Name { get; set; }
    }
}
