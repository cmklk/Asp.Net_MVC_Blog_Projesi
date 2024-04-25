using DataAccessLayer.Concrete;
using MvcBlogProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    public class ChartController : Controller
    {


        public ActionResult VisualizeResult2()
        {
            return Json(GetChartList(), JsonRequestBehavior.AllowGet);
        }


        public List<Chart> GetChartList()
        {
            List<Chart> cs = new List<Chart>();
            using(var c = new Context())
            {
                cs = c.blogs.Select(x=> new Chart
                {
                    BlogTitle = x.BlogTitle,
                    BlogRating = x.BlogRating
                }).ToList();
            }

            return cs;
        }

       public ActionResult Chart()
        {
            return View();
        }
    }
}