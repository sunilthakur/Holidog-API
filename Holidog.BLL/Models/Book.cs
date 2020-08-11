using Holidog.DAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Holidog.BLL.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Isbn { get; set; }
        public int AuthorId { get; set; }

        public BookModel() { }
        public BookModel(Book book)
        {
            this.BookId = book.BookId;
            this.Name = book.Name;
            this.Isbn = book.Isbn;
            this.AuthorId = book.AuthorId;
        }
    }
}
