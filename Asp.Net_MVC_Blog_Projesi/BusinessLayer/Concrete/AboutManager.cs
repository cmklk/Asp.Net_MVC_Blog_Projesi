using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class AboutManager
    {
        Repository<About> AboutMan = new Repository<About>();

        public List<About> getList()
        {
            return AboutMan.List();
        }


        public void AboutContentUpdate(About p)
        {
            About about = AboutMan.Find(x => x.AboutId == p.AboutId);
            about.AboutContent1 = p.AboutContent1;
            about.AboutContent2 = p.AboutContent2;
            about.AboutImage1 = p.AboutImage1;
            about.AboutImage2 = p.AboutImage2;
             AboutMan.Update(about);
            
        }
    }
}
