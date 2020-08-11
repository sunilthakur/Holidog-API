using Holidog.DAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Holidog.BLL
{
    public class DbContext : IDisposable
    {
        /// <summary>
        /// protected, so it only visible for inherited class
        /// </summary>
        [ThreadStatic]
        protected static Holidog_dbContext Context;

        /// <summary>
        /// Initialize Db Context
        /// </summary>
        public DbContext()
        {
            if (Context == null)
            {
                Context = new Holidog_dbContext();
            }
        }


        /// <summary>
        /// Dispose the context
        /// </summary>
        public void Dispose()
        {
            //if (Context != null)
            //{
            //    Context.Dispose();

            //    Context = null;
            //}
        }

        /// <summary>
        /// Reinitiate the database context.
        /// </summary>
        public void ReinitiateContext()
        {
            Dispose();
            Context = new Holidog_dbContext();
        }
    }
}
