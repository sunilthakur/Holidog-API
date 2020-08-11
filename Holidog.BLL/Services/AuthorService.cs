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
    public class AuthorService : BaseService, IAuthorService
    {
        public ActionOutput AddAuthorDetails(AuthorModel author)
        {
            try
            {
                var model = new Author
                {
                    FirstName=author.FirstName,
                    LastName=author.LastName
                };
                Context.Author.Add(model);
                Context.SaveChanges();
                return new ActionOutput
                {
                    Status = ActionStatus.Successfull,
                    Message = "Author details have been added successfully."
                };
            }
            catch (Exception ex)
            {
                return new ActionOutput
                {
                    Status = ActionStatus.Error,
                    Message = "Error while saving author details :" + ex.ToString()
                };
            }
        }

        public ActionOutput DeleteAuthor(int authorId)
        {
            try
            {
                var author = Context.Author.Find(authorId);
                if (author != null)
                {
                    Context.Author.Remove(author);
                    Context.SaveChanges();
                }
                return new ActionOutput
                {
                    Status = ActionStatus.Successfull,
                    Message = "Author has have been removed successfully."
                };
            }
            catch (Exception ex)
            {
                return new ActionOutput
                {
                    Status = ActionStatus.Error,
                    Message = "Error while removing author details :" + ex.ToString()
                };
            }
        }

        public AuthorModel GetAuthorById(int authorId)
        {
            var author = Context.Author.Find(authorId);
            if (author != null)
            {
                return new AuthorModel(author);
            }
            return null;
        }

        public PagingResult<AuthorModel> GetAuthorsPagedList(PagingModel model)
        {
            var result = new PagingResult<AuthorModel>();
            var query = Context.Author.OrderBy(model.SortBy + " " + model.SortOrder);
            if (!string.IsNullOrEmpty(model.Search))
            {
                query = query.Where(z => z.FirstName.ToLower().Contains(model.Search.ToLower()) || z.LastName.ToLower().Contains(model.Search.ToLower())).OrderBy(model.SortBy + " " + model.SortOrder);
            }
            var list = query
               .Skip((model.PageNo - 1) * model.RecordsPerPage).Take(model.RecordsPerPage)
               .ToList().Select(x => new AuthorModel(x)).ToList();
            result.List = list;
            result.Status = ActionStatus.Successfull;
            result.Message = "Author List";
            result.TotalCount = query.Count();
            return result;
        }

        public ActionOutput UpdateAuthorDetails(AuthorModel author)
        {
            var authorDetails = Context.Author.FirstOrDefault(z => z.AuthorId == author.AuthorId);
            if (authorDetails == null)
            {
                return new ActionOutput
                {
                    Status = ActionStatus.Error,
                    Message = "This author does not exist."
                };
            }
            else
            {
                authorDetails.FirstName = author.FirstName;
                authorDetails.LastName = author.LastName;
                Context.SaveChanges();
                return new ActionOutput
                {
                    Status = ActionStatus.Successfull,
                    Message = "Author details have been updated successfully."
                };
            }
        }
    }
}
