using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;

using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlogProje.Controllers
{

 
    public class UserController : Controller
    {

        UserManager userM = new UserManager();
        BlogManager bm = new BlogManager();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Partial1(string p)
        {
            p = (string)Session["Mail"];
            var AuthorInf = userM.GetAuthorInfo(p);
            return PartialView(AuthorInf);
        }

        public ActionResult UserUpdate(Author p)
        {
            userM.UpdateAuthorInfo(p);
            return RedirectToAction("Index");
        }



        public ActionResult GetBlogByAuthor(string p)
        {
            p = (string)Session["Mail"];
            Context c = new Context();
            var id = c.authors.Where(x => x.Mail == p).Select(x => x.AuthorId).FirstOrDefault();
            var AuthorBlog = userM.GetBlogByAuthorList(id);
            return View(AuthorBlog);
        }
    



        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog blog = bm.FindBlog(id);
            Context c = new Context();
            List<SelectListItem> Category = (from x in c.categories.ToList()
                                             select new SelectListItem
                                             {

                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();


            ViewBag.deger1 = Category;
            var BlogFind = userM.BlogFind(id);
            return View(BlogFind);
        }


        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
           userM.BlogUpdate(p);
            return RedirectToAction("GetBlogByAuthor");
        }

        [HttpGet]
        public ActionResult AddBlog()
        {
            Context c = new Context();
            List<SelectListItem> Category = (from x in c.categories.ToList()
                                             select new SelectListItem
                                             {

                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();


            ViewBag.deger1 =Category;

            List<SelectListItem> Author = (from x in c.authors.ToList()
                                             select new SelectListItem
                                             {

                                                 Text = x.AuthorName,
                                                 Value = x.AuthorId.ToString()

                                             }).ToList();
            ViewBag.deger2 = Author;



            return View();
        }

        [HttpPost]
        public ActionResult AddBlog(Blog p)
        {
            userM.AddBlog(p);
            return RedirectToAction("GetBlogByAuthor");
        }
       


        
      public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("UserLogin","Login");
        }

    }
}