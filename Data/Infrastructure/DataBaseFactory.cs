using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructure
{
    public class DataBaseFactory : Disposable, IDataBaseFactory

    {
        private DbContext dataContext;
        public DbContext DataContext
        {
            get { return dataContext; }
        }
        public DataBaseFactory() { dataContext = new ExamenContext(); }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }

}
