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
    [AllowAnonymous]
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        public ActionResult AdminLogin(Admin p )
        {
            Context c = new Context();
            var adminLogin = c.admins.FirstOrDefault(x => x.AdminUsername == p.AdminUsername && x.AdminPassword == p.AdminPassword);

            if(adminLogin != null)
            {
                FormsAuthentication.SetAuthCookie(adminLogin.AdminUsername, false);
                Session["user"] = adminLogin.AdminUsername.ToString();
                return RedirectToAction("AdminBlog", "Blog");
            }

            else
            {
                return RedirectToAction("AdminLogin","Admin");
            }

           
        }
    }
}