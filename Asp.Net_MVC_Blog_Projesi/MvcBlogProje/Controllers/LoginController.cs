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
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UserLogin(Author p)
        {
            Context c = new Context(); // Author entity içerisindeki verilere ulaşmam gerek.
            var User = c.authors.FirstOrDefault(x => x.Mail == p.Mail && x.AuthorPassword == p.AuthorPassword);

            if(User != null)
            {
                FormsAuthentication.SetAuthCookie(User.Mail, false); // form yetkisi sisteme giriş yapan kişi de olmalı kişinin bilgilerini hazırlandığı aşama
                Session["Mail"] = User.Mail.ToString(); // mail adresine kişinin bilgilerini taşıyoruz
                return RedirectToAction("Index", "User");
            }

            else
            {
                return RedirectToAction("UserLogin","Login");
            }


         
        }
    }
}