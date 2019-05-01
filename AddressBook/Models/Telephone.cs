using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AddressBook.Models
{
    public class Telephone
    {
        public int TelephoneId { get; set; }
        [Required]
        public string Number { get; set; }

        public int ContactId { get; set; }
        public Contact contact { get; set; }
    }
}