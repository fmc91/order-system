using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class AddressModel
    {
        public AddressModel(int addressId, int countryId, string streetAddress1, string city, string postalCode)
        {
            AddressId = addressId;
            CountryId = countryId;
            StreetAddress1 = streetAddress1;
            City = city;
            PostalCode = postalCode;
        }

        public int AddressId { get; set; }

        public int CountryId { get; set; }

        public string StreetAddress1 { get; set; }

        public string? StreetAddress2 { get; set; }

        public string? Locality { get; set; }

        public string City { get; set; }

        public string? AdministrativeDistrict { get; set; }

        public string PostalCode { get; set; }

        public string? Country { get; set; }
    }
}
