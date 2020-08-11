using Holidog.DAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Holidog.BLL.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Isbn { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public BookViewModel() { }
        public BookViewModel(Book book)
        {
            this.BookId = book.BookId;
            this.Name = book.Name;
            this.Isbn = book.Isbn;
            this.AuthorId = book.AuthorId;
            this.AuthorName = book.Author.FirstName + " " + book.Author.LastName;
        }
    }
}
