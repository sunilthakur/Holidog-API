using Holidog.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Holidog.BLL.Interfaces
{
    public interface IBookService
    {
        /// <summary>
        /// Get List of books to be displayed using pagination schemea
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        PagingResult<BookViewModel> GetBooksPagedList(PagingModel model);

        /// <summary>
        /// Add new book details
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        ActionOutput AddBookDetails(BookModel BookModel);

        /// <summary>
        /// Update book details 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        ActionOutput UpdateBookDetails(BookModel book);

        /// <summary>
        /// Get book details by passing bookId
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        BookModel GetBookById(int bookId);

        /// <summary>
        /// Remove book details from database by passing bookId
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        ActionOutput DeleteBook(int bookId);

    }
}
