using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace YCBlogsCore.Data
{
    public interface IUnitOfWork:IDisposable
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
