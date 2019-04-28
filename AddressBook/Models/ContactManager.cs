using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook.Models
{
    public class ContactManager
    {
        public Contact GetSingleContact(int TargetId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Contact target = new Contact();

            using (db)
            {
                target = db.Contacts.Where(c => c.ContactId == TargetId).FirstOrDefault();
            }
            return target;
        }

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

        public void DeleteContact(int TargetId)
        {
            //Contact contact = GetSingleContact(TargetId);
            ApplicationDbContext db = new ApplicationDbContext();

            using (db)
            {
                var contact = db.Contacts.Where(c => c.ContactId == TargetId).First();
                var relatedNumbers = db.Telephones.Where(t => t.contact.ContactId == TargetId).ToList();
                var deleteQuery = db.Contacts.Remove(contact);
                var deleteNumbers = db.Telephones.RemoveRange(relatedNumbers);
                db.SaveChanges();                
            }

        }

        public void EditContact(Contact contact)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            using (db)
            {
                Contact target = db.Contacts.Where(t => t.ContactId == contact.ContactId).First();
                target.FirstName = contact.FirstName;
                target.LastName = contact.LastName;
                target.Email = contact.Email;
                target.Address = contact.Address;
                db.SaveChanges();
            }
        }
    }
}