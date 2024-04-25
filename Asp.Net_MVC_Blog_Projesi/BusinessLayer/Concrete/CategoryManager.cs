
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class CategoryManager
    {
        Repository<Category> RepoCategory = new Repository<Category>();
       


        public List<Category> getALL()
        {
            return RepoCategory.List();
        }



        public List<Category> getAll()
        {
            return RepoCategory.List();
        }


        public int addCategory(Category p)
        {
            if(p.CategoryName =="" && p.CategoryDescription == "")
            {
                return -1;
            }

            return RepoCategory.Insert(p);
        }


        public Category findCategory(int id)
        {
            return RepoCategory.Find(x => x.CategoryId == id);
        }

        public int updateCategory(Category p)
        {
            Category category = RepoCategory.Find(x => x.CategoryId == p.CategoryId);
            category.CategoryName = p.CategoryName;
            category.CategoryDescription = p.CategoryDescription;
            return RepoCategory.Update(category);
        }

    

        public int categoryDelete (int id)
        {
            Category category = RepoCategory.Find(x => x.CategoryId == id);
            return RepoCategory.Delete(category);
        }


        public void CategoryDelete(int id)
        {
            Category category = RepoCategory.Find(x => x.CategoryId == id);
            category.CategoryStatus = false;
             RepoCategory.Update(category);
        }
       

        public void CategoryStatusTrue(int id)
        {
            Category category = RepoCategory.Find(x => x.CategoryId == id);
            category.CategoryStatus = true;
             RepoCategory.Update(category);
        }



     

       
    }
}
