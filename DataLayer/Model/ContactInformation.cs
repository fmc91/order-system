using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class ContactInformation
    {
        public ContactInformation(int contactInformationId, int contactId, ContactInformationType contactInformationType, string value)
        {
            ContactInformationId = contactInformationId;
            ContactId = contactId;
            ContactInformationType = contactInformationType;
            Value = value;
        }

        public int ContactInformationId { get; set; }

        public int ContactId { get; set; }

        public ContactInformationType ContactInformationType { get; set; }

        public string? Description { get; set; }

        public string Value { get; set; }
    }
}
