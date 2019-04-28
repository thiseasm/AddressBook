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
        public ActionResult Index()
        {
            var allContacts = manager.GetContacts();
            return View(allContacts);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}