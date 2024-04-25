
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
   public class AuthorManager
    {
        Repository<Author> AuthorRepo = new Repository<Author>();
        Repository<Blog> BlogRepo = new Repository<Blog>();


      
          
        public List<Author> getList()
        {
            return AuthorRepo.List();
        }

  


       public int authorAdd(Author p)
        {
            if(p.AuthorName =="" && p.AuthorPassword=="" && p.AuthorImage=="" && p.AhuthotAbout =="" && p.AhuthotAbout=="" && p.AboutShort == "")
            {
                return -1;
            }

            return AuthorRepo.Insert(p);
        }


        public Author findAuthor (int id)
        {
            return AuthorRepo.Find(x => x.AuthorId == id);
        }

      
        public List<Blog> blogbyAuthor (int id)
        {
            return BlogRepo.List(x =>x.AuthorId == id);
        }


        public int AuthorUpdate (Author p)
        {
            Author author = AuthorRepo.Find(x => x.AuthorId == p.AuthorId);
            author.AboutShort = p.AboutShort;
            author.AboutTitle = p.AboutTitle;
            author.AhuthotAbout = p.AhuthotAbout;
            author.AuthorImage = p.AuthorImage;
            author.AuthorName = p.AuthorName;
            author.AuthorPassword = p.AuthorPassword;
            author.Mail = p.Mail;
            author.PhoneNumber = p.PhoneNumber;
            return AuthorRepo.Update(author);
        }






      
    }
}
