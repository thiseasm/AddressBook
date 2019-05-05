using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AddressBook.Models;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {
        ContactManager manager = new ContactManager();
        public ActionResult Index(string searchString)
        {
            var allContacts = manager.GetContacts();
            if (!String.IsNullOrEmpty(searchString))
            {
                allContacts = manager.GetContacts(searchString);
            }
            return View(allContacts);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            manager.DeleteContact(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var targetContact = manager.GetSingleContact(id);
            return View(targetContact);
        }

        public ActionResult ViewPhones(int id)
        {
            return RedirectToAction("Index","Phone", new { id = id });
        }
    }
}