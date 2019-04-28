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
            return View(associatedNumbers);
        }

        public ActionResult Delete(int telephoneId)
        {
            int contactId = manager.DeleteTelephone(telephoneId);
            return RedirectToAction("Index", contactId);
        }

    }
}