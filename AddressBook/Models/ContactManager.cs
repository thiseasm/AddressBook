using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook.Models
{
    public class ContactManager
    {
        public void CreateContact(Contact contact)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            using (db)
            {
                var addQuery = db.Contacts.Add(contact);
                db.SaveChanges();
            }

        }
        
        public IEnumerable<Contact> GetContacts()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            IEnumerable<Contact> contacts = Enumerable.Empty<Contact>();

            using (db)
            {
                contacts = db.Contacts.ToList();
            }

            return contacts;
        }
    }
}