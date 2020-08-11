using Holidog.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Holidog.BLL.Interfaces
{
    public interface IAuthorService
    {
        /// <summary>
        /// Get List of Authors to be displayed using pagination schemea
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        PagingResult<AuthorModel> GetAuthorsPagedList(PagingModel model);

        /// <summary>
        /// Add new author details
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        ActionOutput AddAuthorDetails(AuthorModel author);

        /// <summary>
        /// Update Author details 
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        ActionOutput UpdateAuthorDetails(AuthorModel author);

        /// <summary>
        /// Get Author details by passing authorId
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        AuthorModel GetAuthorById(int authorId);

        /// <summary>
        /// Remove author details from database by passing authorId
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        ActionOutput DeleteAuthor(int authorId);
    }
}
