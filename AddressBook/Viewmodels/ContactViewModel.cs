using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AddressBook.Models;

namespace AddressBook.Viewmodels
{
    public class ContactViewModel
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public IEnumerable<Telephone> Phonebook { get; set; }
    }
}