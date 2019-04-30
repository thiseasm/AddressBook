using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AddressBook.Models;

namespace AddressBook.Controllers
{
    public class PhoneController : Controller
    {
        ContactManager manager = new ContactManager();
        public ActionResult Index(int id)
        {
            var associatedNumbers = manager.GetTelephones(id);
            ViewBag.Contact = manager.GetSingleContact(id);
            return View(associatedNumbers);
        }

        public ActionResult Delete(int telephoneId)
        {
            int contactId = manager.DeleteTelephone(telephoneId);
            return RedirectToAction("Index", new { ContactId = contactId });
        }

        public ActionResult Create(Contact contact)
        {
            ViewBag.Contact = contact;
            return View();
        }

        [HttpPost]
        public ActionResult AppendPhonebook(Telephone telephone)
        {
            manager.AppendPhones(telephone);
            return RedirectToAction("Index", new { @id = telephone.contact.ContactId });
        }
    }
}