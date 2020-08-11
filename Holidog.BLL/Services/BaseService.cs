using System;
using System.Collections.Generic;
using System.Text;

namespace Holidog.BLL.Services
{
    public abstract class BaseService : DbContext
    {
        public BaseService()
            : base()
        {
            Context = new DAL.Entity.Models.Holidog_dbContext();
        }
        /// <summary>
        /// protected, it only visible for inherited class
        /// </summary>
        protected void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
