using System;
using System.Collections.Generic;

namespace Holidog.DAL.Entity.Models
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Isbn { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
