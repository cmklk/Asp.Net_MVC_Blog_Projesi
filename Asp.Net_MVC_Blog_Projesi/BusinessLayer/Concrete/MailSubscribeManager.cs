using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class MailSubscribeManager
    {
        Repository<SubscribeMail> SubscribeMail = new Repository<SubscribeMail>();

        public void BlAddMail(SubscribeMail p)
        {
             SubscribeMail.Insert(p);
        }
    }
}
