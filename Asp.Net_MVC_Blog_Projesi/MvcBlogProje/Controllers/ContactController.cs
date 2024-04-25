using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager();

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(Contact p) {
            cm.addContact(p);
            return RedirectToAction("Index");    
        }



        public ActionResult AdminContactList()
        {
            var ContactList = cm.getListContactMessage();
            return View(ContactList);
        }

        public ActionResult getContactDetails(int id)
        {
            Contact contact = cm.GetMessageDetails(id);  // contact managerdan GetMessageDetails dışarıdan id adında bir parametre atamasını istedik. Atadığı id benim veritabanımdaki id ye eşitse ilgili alandaki bilgileri bana burada döndür.
            ViewBag.id = id;
            return View(contact);
        }

        public ActionResult ContactDelete (int id)
        {
            cm.ContactDelete(id);
            return RedirectToAction("AdminContactList");
        }
    }
}