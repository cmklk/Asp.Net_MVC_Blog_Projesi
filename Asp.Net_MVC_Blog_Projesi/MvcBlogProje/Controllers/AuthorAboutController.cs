using BusinessLayer.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    public class AuthorAboutController : Controller
    {
        BlogManager bm = new BlogManager();

        [AllowAnonymous]
        public PartialViewResult Author(int id)
        {
            var AuthorID = bm.GetByID(id);
            return PartialView(AuthorID);
        }

        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogAuthorId = bm.getAll().Where(x => x.BlogId == id).Select(x => x.AuthorId).FirstOrDefault();
            var BlogAuthor = bm.GetBlogByAuthor(blogAuthorId);
            return PartialView(BlogAuthor);
        }

     
    }
}