using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class ContactModel
    {
        public ContactModel(int contactId, string firstName, string lastName, string role)
        {
            ContactId = contactId;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            ContactInformation = new List<ContactInformation>();
        }

        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Role { get; set; }

        public List<ContactInformation> ContactInformation { get; }
    }
}
