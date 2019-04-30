using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AddressBook.Viewmodels;

namespace AddressBook.Models
{
    public class ContactManager
    {
        public Contact GetSingleContact(int targetId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Contact target = new Contact();

            using (db)
            {
                target = db.Contacts.Where(c => c.ContactId == targetId).FirstOrDefault();
            }
            return target;
        }

        public IEnumerable<Telephone> GetTelephones(int targetId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            IEnumerable<Telephone> telephones = Enumerable.Empty<Telephone>();

            using (db)
            {
                telephones = db.Telephones.Where(t => t.contact.ContactId == targetId).ToList();
            }

            return telephones;
        }

        public int DeleteTelephone(int targetId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            int contactId;
            using (db)
            {
                var telephone = db.Telephones.Where(t => t.TelephoneId == targetId).FirstOrDefault();
                contactId = telephone.contact.ContactId;
                var deleteQuery = db.Telephones.Remove(telephone);
                db.SaveChanges();
            }
            return contactId;
        }

        public void AppendPhones(Telephone telephone)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            using (db)
            {
                var appendQuery = db.Telephones.Add(telephone);
                db.SaveChanges();
            }
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
                contacts = db.Contacts.Include("Telephones.Contact").ToList();
            }
            return contacts;
        }

        public void DeleteContact(int TargetId)
        {
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