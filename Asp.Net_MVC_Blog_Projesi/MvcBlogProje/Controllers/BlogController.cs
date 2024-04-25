using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;

using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager();
        CommentManager cm = new CommentManager();
        AuthorManager am = new AuthorManager();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        public PartialViewResult BlogList(int page=1)
        {
            var BlogValues = bm.getAll().ToPagedList(page,3);
            return PartialView(BlogValues);
        }

        [AllowAnonymous]
        public PartialViewResult FeaturePost()
        {
           


            var blogTitle = bm.getAll().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 4).Select(x => x.BlogTitle).FirstOrDefault();
            var blogImage = bm.getAll().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 4).Select(x => x.BlogImage).FirstOrDefault();
            var blogDate = bm.getAll().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 4).Select(x => x.BlogDate).FirstOrDefault();
       
            ViewBag.blogTitle1 = blogTitle;
            ViewBag.blogImage1 = blogImage;
            ViewBag.blogDate1 = blogDate;



            var blogTitle2 = bm.getAll().OrderBy(x => x.BlogId).Where(x => x.CategoryId == 4).Select(x => x.BlogTitle).FirstOrDefault();
            var blogImage2 = bm.getAll().OrderBy(x => x.BlogId).Where(x => x.CategoryId == 4).Select(x => x.BlogImage).FirstOrDefault();
            var blogDate2 = bm.getAll().OrderBy(x => x.BlogId).Where(x => x.CategoryId == 4).Select(x => x.BlogDate).FirstOrDefault();

            ViewBag.blogTitle2 = blogTitle2;
            ViewBag.blogImage2 = blogImage2;
            ViewBag.blogDate2 = blogDate2;


            var blogTitle3 = bm.getAll().OrderBy(x => x.BlogId).Where(x => x.CategoryId == 1).Select(x => x.BlogTitle).FirstOrDefault();
            var blogImage3 = bm.getAll().OrderBy(x => x.BlogId).Where(x => x.CategoryId == 1).Select(x => x.BlogImage).FirstOrDefault();
            var blogDate3 = bm.getAll().OrderBy(x => x.BlogId).Where(x => x.CategoryId == 1).Select(x => x.BlogDate).FirstOrDefault();

            ViewBag.blogTitle3 = blogTitle3;
            ViewBag.blogImage3 = blogImage3;
            ViewBag.blogDate3 = blogDate3;



            var blogTitle4 = bm.getAll().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 1).Select(x => x.BlogTitle).FirstOrDefault();
            var blogImage4 = bm.getAll().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 1).Select(x => x.BlogImage).FirstOrDefault();
            var blogDate4 = bm.getAll().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 1).Select(x => x.BlogDate).FirstOrDefault();

            ViewBag.blogTitle4 = blogTitle4;
            ViewBag.blogImage4 = blogImage4;
            ViewBag.blogDate4= blogDate4;


            var blogTitle5 = bm.getAll().OrderBy(x => x.BlogId).Where(x => x.CategoryId == 9).Select(x => x.BlogTitle).FirstOrDefault();
            var blogImage5 = bm.getAll().OrderBy(x => x.BlogId).Where(x => x.CategoryId == 9).Select(x => x.BlogImage).FirstOrDefault();
            var blogDate5 = bm.getAll().OrderBy(x => x.BlogId).Where(x => x.CategoryId == 9).Select(x => x.BlogDate).FirstOrDefault();

            ViewBag.blogTitle5 = blogTitle5;
            ViewBag.blogImage5 = blogImage5;
            ViewBag.blogDate5= blogDate5;





            var blogFeaturedPost1 = bm.getAll().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 4).Select(x => x.BlogId).FirstOrDefault();
            ViewBag.FeaturedPost1 = blogFeaturedPost1;



            var blogFeaturedPost2 = bm.getAll().OrderBy(x => x.BlogId).Where(x => x.CategoryId == 4).Select(x => x.BlogId).FirstOrDefault();
            ViewBag.FeaturedPost2 = blogFeaturedPost2;


            var blogFeaturedPost3 = bm.getAll().OrderBy(x => x.BlogId).Where(x => x.CategoryId == 1).Select(x => x.BlogId).FirstOrDefault();
            ViewBag.FeaturedPost3 = blogFeaturedPost3;


            var blogFeaturedPost4 = bm.getAll().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 1).Select(x => x.BlogId).FirstOrDefault();
            ViewBag.FeaturedPost4 = blogFeaturedPost4;

            var blogFeaturedPost5 = bm.getAll().OrderBy(x => x.BlogId).Where(x => x.CategoryId == 9).Select(x => x.BlogId).FirstOrDefault();
            ViewBag.FeaturedPost5 = blogFeaturedPost5;


            return PartialView();
        }


        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return View();
        }


        [AllowAnonymous]
        public PartialViewResult Blogcover(int id)
        {
            var blogDetailsId = bm.GetByID(id);
            return PartialView(blogDetailsId);
        }

        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var blogDetailsId = bm.GetByID(id);
            return PartialView(blogDetailsId);
        }


        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var BlogListCategory = bm.GetBlogByCategory(id);
            var CategoryName= bm.GetBlogByCategory(id).Select(x => x.Category.CategoryName).FirstOrDefault();
            var CategoryDescription = bm.GetBlogByCategory(id).Select(x => x.Category.CategoryDescription).FirstOrDefault();
            ViewBag.Name = CategoryName;
            ViewBag.Description = CategoryDescription;
            return View(BlogListCategory);
        }





        public ActionResult AdminBlog()
        {
            var blogList = bm.getAll();
            return View(blogList);
        }


        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            List<SelectListItem> Category = (from x in c.categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();


            ViewBag.CategoryNames = Category;



            List<SelectListItem> Author = (from x in c.authors.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AuthorName,
                                               Value = x.AuthorId.ToString()
                                           }).ToList();

            ViewBag.AuthorNames = Author;
            return View();
        }

        [HttpPost]
        public ActionResult AddNewBlog(Blog p)
        {
                bm.addBlog(p);
                return RedirectToAction("AdminBlog");
       
         
        }



        public ActionResult deleteBlog (int id)
        {
            bm.deleteBlog(id);
            return RedirectToAction("AdminBlog");
        }




     [HttpGet]
        public ActionResult GetBlogDetails(int id)
        {

            Blog blog = bm.FindBlog(id);
            Context c = new Context();
            List<SelectListItem> Category = (from x in c.categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()

                                             }).ToList();


            ViewBag.CategoryName = Category;


            List<SelectListItem> Author = (from x in c.authors.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.AuthorName,
                                                 Value = x.AuthorId.ToString()

                                             }).ToList();


            ViewBag.AuthorName = Author;

            return View(blog);
        
        }


        [HttpPost]
        public ActionResult GetBlogDetails(Blog p)
        {
            bm.UpdateBlog(p);
            return RedirectToAction("AdminBlog");
        }


        public ActionResult BlogCommentDetails(int id)
        {
            var BlogList = cm.BlogAdminCommentList(id);
            return View(BlogList);
        }
     
      

        public ActionResult BlogByAuthor (int id)
        {
            var blogAuthorList = am.blogbyAuthor(id);
            return View(blogAuthorList);
        }



        
    }


    
}