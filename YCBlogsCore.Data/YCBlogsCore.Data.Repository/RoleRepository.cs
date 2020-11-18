using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YCBlogsCore.Data;
using YCBlogsCore.Data.EF;
using YCBlogsCore.Domain.Models;

namespace YCBlogsCore.Data.Repository
{
    public interface IRoleRepository:IRepository<Role, Int32>
    {

    }
    public class RoleRepository : Repository<Role, Int32>, IRoleRepository
    {
        public RoleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
