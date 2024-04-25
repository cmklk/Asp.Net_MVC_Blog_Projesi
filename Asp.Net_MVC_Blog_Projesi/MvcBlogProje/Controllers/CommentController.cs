using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager();


        public ActionResult CommentListTrue()
        {
            var ListTrue = cm.CommentStatusTrue();
            return View(ListTrue);
        }

        public ActionResult CommentListFalse()
        {
            var ListFalse = cm.CommentStatusFalse();
            return View(ListFalse);
        }


        [AllowAnonymous]
        public PartialViewResult CommnetList(int id)
        {
            var BlogCommentList = cm.BlogCommentListId(id);
            return PartialView(BlogCommentList);
        }


        [HttpGet]
        [AllowAnonymous]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.deger1 = id;
            return PartialView();
        }


        [HttpPost]
        [AllowAnonymous]
        public PartialViewResult LeaveComment(Comment c)
        {
            c.CommentStatus = true;
            cm.AddComment(c);
            return PartialView();
        }


        public ActionResult CommentChangeStatusToFalse(int id)
        {
            cm.CommentStatusToChange(id);
            return RedirectToAction("CommentListTrue");
        }
       

        public ActionResult CommentStatusToTrue(int id)
        {
            cm.CommentStatusChangeToTrue(id);
            return RedirectToAction("CommentListFalse");
        }
    }
}