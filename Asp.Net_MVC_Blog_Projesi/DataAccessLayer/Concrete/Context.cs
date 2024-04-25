﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
   public class Context:DbContext
    {
        public DbSet<About> abouts { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<SubscribeMail> subscribeMails { get; set; }
    }
}