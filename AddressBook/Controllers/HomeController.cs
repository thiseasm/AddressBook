using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AddressBook.Models;
using PagedList;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {
        ContactManager manager = new ContactManager();
        public ActionResult Index(string searchString, string currentFilter, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var allContacts = manager.GetContacts();
            if (!String.IsNullOrEmpty(searchString))
            {
                allContacts = manager.GetContacts(searchString);
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(allContacts.ToPagedList(pageNumber, pageSize));
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