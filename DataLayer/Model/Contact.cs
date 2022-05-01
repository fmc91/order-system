using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Contact
    {
        public Contact(int contactId, int customerId, string firstName, string lastName, string role)
        {
            ContactId = contactId;
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            ContactInformation = new HashSet<ContactInformation>();
        }

        public int ContactId { get; set; }

        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Role { get; set; }

        public virtual ICollection<ContactInformation> ContactInformation { get; }
    }
}
