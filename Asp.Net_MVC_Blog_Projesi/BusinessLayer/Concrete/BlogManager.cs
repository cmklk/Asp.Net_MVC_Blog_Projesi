
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
   public class BlogManager
    {
        Repository<Blog> RepoBlog = new Repository<Blog>();
        Repository<Author> RepoAuthor = new Repository<Author>();

        public List<Blog> getAll()
        {
            return RepoBlog.List();
        }



        public List<Blog> GetByID(int id)
        {
            return RepoBlog.List(x => x.BlogId == id);
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return RepoBlog.List(x => x.AuthorId == id);
        }

        public List<Blog> GetBlogByCategory(int id)
        {
            return RepoBlog.List(x=>x.CategoryId==id);
        }


     

        public int deleteBlog (int id)
        {
            Blog blog = RepoBlog.Find(x => x.BlogId == id);
            return RepoBlog.Delete(blog);
        }

        public int addBlog(Blog p)
        {
            if(p.BlogTitle=="" && p.BlogImage=="" && p.BlogContent=="")
            {
                return -1;
            }

          return  RepoBlog.Insert(p);
        }

        public Blog FindBlog(int id)
        {
            return RepoBlog.Find(x => x.BlogId == id);
        }


        public int UpdateBlog(Blog p)
        {
            Blog blog = RepoBlog.Find(x => x.BlogId == p.BlogId); // güncellenecek ıd değeri alınmalı
            blog.BlogTitle = p.BlogTitle;  // blog da bulunan title dışarıdan inputtan girilecek değer neyse değişecek.
            blog.BlogContent = p.BlogContent;
            blog.BlogDate = p.BlogDate;
            blog.BlogImage = p.BlogImage;
            blog.CategoryId = p.CategoryId;
            blog.AuthorId = p.AuthorId;
            return RepoBlog.Update(blog);
        }


    }
}
