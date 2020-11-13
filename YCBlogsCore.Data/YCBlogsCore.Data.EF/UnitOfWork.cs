using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace YCBlogsCore.Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;
        private bool disposed=false;
        public UnitOfWork(DbContext dbContext) {
            context = dbContext ?? throw new ArgumentNullException(nameof(context));
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
