using Holidog.BLL.Interfaces;
using Holidog.BLL.Models;
using Holidog.DAL.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic.Core;

namespace Holidog.BLL.Services
{
    public class BookService : BaseService, IBookService
    {
        public ActionOutput AddBookDetails(BookModel book)
        {
            try
            {
                var model = new Book
                {
                    AuthorId = book.AuthorId,
                    Isbn = book.Isbn,
                    Name = book.Name
                };
                Context.Book.Add(model);
                Context.SaveChanges();
                return new ActionOutput
                {
                    Status = ActionStatus.Successfull,
                    Message = "Book details have been added successfully."
                };
            }
            catch (Exception ex)
            {
                return new ActionOutput
                {
                    Status = ActionStatus.Error,
                    Message = "Error while saving book details :" + ex.ToString()
                };
            }
        }

        public ActionOutput DeleteBook(int bookId)
        {
            try
            {
                var book = Context.Book.Find(bookId);
                if (book != null)
                {
                    Context.Book.Remove(book);
                    Context.SaveChanges();
                }
                return new ActionOutput
                {
                    Status = ActionStatus.Successfull,
                    Message = "Book has have been removed successfully."
                };
            }
            catch (Exception ex)
            {
                return new ActionOutput
                {
                    Status = ActionStatus.Error,
                    Message = "Error while removing book details :" + ex.ToString()
                };
            }
        }

        public BookModel GetBookById(int bookId)
        {
            var book = Context.Book.Find(bookId);
            if (book != null)
            {
                return new BookModel(book);
            }
            return null;
        }

        public PagingResult<BookViewModel> GetBooksPagedList(PagingModel model)
        {
            var result = new PagingResult<BookViewModel>();
            var query = Context.Book.Include(x=>x.Author).OrderBy(model.SortBy + " " + model.SortOrder);
            if (!string.IsNullOrEmpty(model.Search))
            {
                query = query.Where(z => z.Name.ToLower().Contains(model.Search.ToLower()) || z.Isbn.ToLower().Contains(model.Search.ToLower())).OrderBy(model.SortBy + " " + model.SortOrder);
            }
            var list = query
               .Skip((model.PageNo - 1) * model.RecordsPerPage).Take(model.RecordsPerPage)
               .ToList().Select(x => new BookViewModel(x)).ToList();
            result.List = list;
            result.Status = ActionStatus.Successfull;
            result.Message = "Book List";
            result.TotalCount = query.Count();
            return result;
        }

        public ActionOutput UpdateBookDetails(BookModel book)
        {
            var bookDetails = Context.Book.FirstOrDefault(z => z.BookId == book.BookId);
            if (bookDetails == null)
            {
                return new ActionOutput
                {
                    Status = ActionStatus.Error,
                    Message = "This book does not exist."
                };
            }
            else
            {
                bookDetails.Name = book.Name;
                bookDetails.AuthorId = book.AuthorId;
                bookDetails.Isbn = book.Isbn;
                Context.SaveChanges();
                return new ActionOutput
                {
                    Status = ActionStatus.Successfull,
                    Message = "Book details have been updated successfully."
                };
            }
        }
    }
}
