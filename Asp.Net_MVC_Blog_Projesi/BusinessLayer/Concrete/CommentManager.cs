using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class CommentManager
    {
        Repository<Comment> CommentRepo = new Repository<Comment>();

        public List<Comment> BlogCommentListId(int id)
        {
            return CommentRepo.List(x => x.BlogId == id);
        }

        public void AddComment(Comment p)
        {
         
             CommentRepo.Insert(p);
        }

        public List<Comment> BlogAdminCommentList(int id)
        {
            return CommentRepo.List(x => x.BlogId == id);
        }


        // statusu true olanları listeleme
        public List<Comment> CommentStatusTrue()
        {
            return CommentRepo.List(x => x.CommentStatus == true);
        }

        // statusu false olanları listeleme

        public List<Comment> CommentStatusFalse()
        {
            return CommentRepo.List(x => x.CommentStatus==false);
        }

        


        public void CommentStatusToChange(int id)
        {
            Comment comment = CommentRepo.Find(x => x.CommnetId == id);
            comment.CommentStatus = false;
             CommentRepo.Update(comment);

        }

        public void CommentStatusChangeToTrue(int id)
        {
            Comment comment = CommentRepo.Find(x => x.CommnetId == id);
            comment.CommentStatus = true;
             CommentRepo.Update(comment);
        }
    }
}
