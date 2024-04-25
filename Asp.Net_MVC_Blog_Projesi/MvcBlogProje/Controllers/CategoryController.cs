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
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager();
        BlogManager bm = new BlogManager();


        [AllowAnonymous]
        public PartialViewResult BlogCategoryList()
        {
            var categoryList = cm.getALL();
            return PartialView(categoryList);
        }




        public ActionResult AdminCategoryList()
        {
            var categoryList = cm.getALL();
            return View(categoryList);
        }




        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }



        [HttpPost]
        public ActionResult CategoryAdd(Category p)
        {
            cm.addCategory(p);
            return RedirectToAction("AdminCategoryList");
        }




        //public ActionResult ForCategoryBlogList(int id)
        //{
        //    var CategoryBlogList = bm.ForCategoryBlogList(id);
        //    return View(CategoryBlogList);
        //}


        public ActionResult CategoryDelete(int id)
        {
             cm.CategoryDelete(id);
            return RedirectToAction("AdminCategoryList");
        }

        public ActionResult CategoryStatusTrue(int id)
        {
            cm.CategoryStatusTrue(id);
            return RedirectToAction("AdminCategoryList");
        }


        [HttpGet]
        public ActionResult CategoryUpdate(int id)
        {
            var findValues = cm.findCategory(id);
            return View(findValues);
        }



        [HttpPost]
        public ActionResult CategoryUpdate(Category p)
        {
            cm.updateCategory(p);
            return RedirectToAction("AdminCategoryList");
             
          
        }
        
    }
}