﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Study.Model
{
    public class BookDetail
    {
        [Key]
        public int BookDetail_Id { get; set; }
        [Required]
        public int NumberOfChapters { get; set; }
        public int NumberOfPages { get; set; }
        public string Weight { get; set; }
        [ForeignKey("Book")] //it needs to do the reverse mapping too
        // the fk must be in the child class?
        public int Book_Id { get; set; }
        public virtual Book Book { get; set; }
    }
}
