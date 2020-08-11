using System;
using System.Collections.Generic;

namespace Holidog.DAL.Entity.Models
{
    public partial class Author
    {
        public Author()
        {
            Book = new HashSet<Book>();
        }

        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
