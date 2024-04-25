using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class UserManager
    {
        Repository<Author> AuthorRepo = new Repository<Author>();
        Repository<Blog> BlogRepo = new Repository<Blog>();

        public List<Author> GetAuthorInfo(string p)
        {
            return AuthorRepo.List(x => x.Mail == p);
        }

        public int UpdateAuthorInfo(Author p)
        {
            Author author = AuthorRepo.Find(x => x.AuthorId == p.AuthorId);
            author.AuthorName = p.AuthorName;
            author.AuthorImage = p.AuthorImage;
            author.AboutTitle = p.AboutTitle;
            author.AuthorPassword = p.AuthorPassword;
           
            author.PhoneNumber = p.PhoneNumber;
            author.AhuthotAbout = p.AhuthotAbout;
            author.AboutShort = p.AboutShort;
             return AuthorRepo.Update(author);
        }


        public List<Blog> GetBlogByAuthorList(int id) {
            return BlogRepo.List(x=>x.AuthorId==id);
        }


        public Blog BlogFind(int id)
        {
            return BlogRepo.Find(x => x.BlogId == id);
        }


        public int BlogUpdate(Blog p)
        {
            Blog Blog = BlogRepo.Find(x => x.BlogId == p.BlogId);
            Blog.BlogTitle = p.BlogTitle;
            Blog.BlogImage = p.BlogImage;
            Blog.BlogRating = p.BlogRating;
            Blog.BlogContent = p.BlogContent;
            Blog.CategoryId = p.CategoryId;
            return BlogRepo.Update(Blog);
        }


        public int AddBlog(Blog p)
        {
           
           return  BlogRepo.Insert(p);
        }




        

    }
}
