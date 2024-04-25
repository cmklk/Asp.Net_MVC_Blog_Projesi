using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    
   public class ContactManager
    {
        Repository<Contact> ContactRepo = new Repository<Contact>();

        public List<Contact> getListContactMessage()
        {
            return ContactRepo.List();
        }



        public void addContact(Contact p)
        {
            
             ContactRepo.Insert(p);
        }


        public Contact GetMessageDetails(int id)
        {
            return ContactRepo.Find(x => x.ContactId == id);
        }

        public void ContactDelete(int id)
        {
            Contact contact = ContactRepo.Find(x => x.ContactId == id);
             ContactRepo.Delete(contact);
        }
    }
}
