using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AddressBook.Models;

namespace AddressBook.Controllers
{
    public class CreateController : Controller
    {
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            ContactManager manager = new ContactManager();
            manager.CreateContact(contact);
            return RedirectToAction("Index", "Home");
        }
    }
}