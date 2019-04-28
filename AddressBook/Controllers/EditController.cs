using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddressBook.Controllers
{
    public class EditController : Controller
    {
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            ContactManager manager = new ContactManager();
            manager.EditContact(contact);
            return RedirectToAction("Index","Home");
        }
    }
}