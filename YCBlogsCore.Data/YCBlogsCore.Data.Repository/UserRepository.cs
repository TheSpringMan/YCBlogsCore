using System;
using System.Collections.Generic;
using System.Text;
using YCBlogsCore.Domain.Models;
using YCBlogsCore.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace YCBlogsCore.Data.Repository
{
    public interface IUserRepository:IRepository<User, Int32>
    {

    }

    public class UserRepository : Repository<User, Int32>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
