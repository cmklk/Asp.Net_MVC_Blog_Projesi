using BusinessLayer.Concrete;

using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    public class AboutController : Controller
    {
        AboutManager ab = new AboutManager();
        
        [AllowAnonymous]
        public ActionResult Index()
        {
            var AboutList = ab.getList();
            return View(AboutList);
        }


        [AllowAnonymous]
        public PartialViewResult MeetTheTeam()
        {
            AuthorManager au = new AuthorManager();

            var AuthorList = au.getList();
            return PartialView(AuthorList);
        }


        [AllowAnonymous]
        public PartialViewResult Footer()
        {
            var aboutList = ab.getList();
            return PartialView(aboutList);
        }



        /*Admin Panelindeki About İşlemleri*/

       [HttpGet]
        public ActionResult AdminAboutList()
        {
            var aboutList = ab.getList();
            return View(aboutList);
        }


        [HttpPost]
        public ActionResult AdminAboutList(About p)
        {
            ab.AboutContentUpdate(p);
            return RedirectToAction("AdminAboutList");
        }
    }
}