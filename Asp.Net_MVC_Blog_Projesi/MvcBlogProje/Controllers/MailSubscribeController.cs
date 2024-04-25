using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    [AllowAnonymous]
    public class MailSubscribeController : Controller
    {

        
        [HttpGet]
        public PartialViewResult MailSubscribeContent()
        {
            return PartialView();
        }

        

        [HttpPost]
        public PartialViewResult MailSubscribeContent(SubscribeMail p)
        {
            MailSubscribeManager bm = new MailSubscribeManager();
            // formda abone yapılmadan önce businesslayerde oluşturduğumuz kısıtlamaları
            //buraya ekledik. Validasyon işlemlerinde sıkınıtı varsa
            // -1 dönecek yoksa veritabanına gerekli işlemler eklenecek.
            bm.BlAddMail(p);
            
            return PartialView();
        }
    }
}