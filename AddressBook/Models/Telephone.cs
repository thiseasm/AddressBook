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
        [Phone]
        [RegularExpression(@"^([0-9]{3})[- ]?([0-9]{3})[- ]?([0-9]{4})$",ErrorMessage = "Please enter a valid telephone")]
        public string Number { get; set; }

        public int ContactId { get; set; }
        public Contact contact { get; set; }
    }
}