﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [StringLength(50)]
        public string AuthorName { get; set; }
        [StringLength(300)]
        public string AuthorImage { get; set; }
        [StringLength(300)]
        public string AhuthotAbout { get; set; }


        [StringLength(50)]
        public string AboutTitle { get; set; }

        [StringLength(100)]
        public string AboutShort { get; set; }

        [StringLength(100)]
        public string Mail { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(10)]
        public string AuthorPassword { get; set; }

        public ICollection<Blog> blogs { get; set; }
    }
}