using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;

using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    public class AuthorController : Controller
    {
        AuthorManager am = new AuthorManager();
        BlogManager bm = new BlogManager();
        public ActionResult Index()
        {
            var AuthorList = am.getList();
            return View(AuthorList);
        }


        [HttpGet]
        public ActionResult AddNewAuthor()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddNewAuthor(Author p)
        {
                 am.authorAdd(p);
                return RedirectToAction("Index");  
        }


        [HttpGet]
        public ActionResult FindAuthorId(int id)
        {
            Author author = am.findAuthor(id);
            return View(author);
        }

        public ActionResult FindAuthorId(Author p)
        {
            am.AuthorUpdate(p);
            return RedirectToAction("Index");
        }



        
    }
}