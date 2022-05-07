using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace OrderSystem.Model
{
    public class ContactInformation
    {
        public ContactInformation(int contactInformationId, ContactInformationType contactInformationType, string value)
        {
            ContactInformationId = contactInformationId;
            ContactInformationType = contactInformationType;
            Value = value;
        }

        public int ContactInformationId { get; set; }

        public ContactInformationType ContactInformationType { get; set; }

        public string? Description { get; set; }

        public string Value { get; set; }
    }
}
