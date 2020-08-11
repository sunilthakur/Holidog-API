using Holidog.DAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Holidog.BLL.Models
{
    public class AuthorModel
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AuthorModel() { }
        public AuthorModel(Author author)
        {
            this.AuthorId = author.AuthorId;
            this.FirstName = author.FirstName;
            this.LastName = author.LastName;
        }
    }
}
