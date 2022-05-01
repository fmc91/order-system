using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Address
    {
        private Country? _country;

        public Address(int addressId, string streetAddress1, string city, string postalCode, int countryId)
        {
            AddressId = addressId;
            StreetAddress1 = streetAddress1;
            City = city;
            PostalCode = postalCode;
            CountryId = countryId;
        }

        public int AddressId { get; set; }

        public string StreetAddress1 { get; set; }

        public string? StreetAddress2 { get; set; }

        public string? Locality { get; set; }

        public string City { get; set; }

        public string? AdministrativeDistrict { get; set; }

        public string PostalCode { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country
        {
            get => _country ??
                throw new InvalidOperationException($"Uninitialized property: {nameof(Country)}");
            set => _country = value;
        }
    }
}
