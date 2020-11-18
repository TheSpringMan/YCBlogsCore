using Microsoft.VisualStudio.TestTools.UnitTesting;
using YCBlogsCore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using YCBlogsCore.Domain.Models;
using YCBlogsCore.Utils.Models;

namespace YCBlogsCore.Data.Repository.Tests
{
    [TestClass()]
    public class UserRepositoryTests
    {
        [TestMethod()]
        public void AddUserTest()
        {
            Utils.GlobalContext.DbConfig = new DbConfigSetting
            {
                DbProvider = "SqlServer",
                ConnectionString = "Server=DESKTOP-F99P808\\SISDB;Database=YCBlogsCoreDB;Trusted_Connection=true;",
                DBSlowSqlLogTime = 0
            };
            User user = new User();
            user.UserName = "TestUser";
            user.Email = "123456@qq.com";
            var context = new YCBlogsCore.Data.EF.EFDbContext();
            UserRepository repository = new UserRepository(context);
            var unitOfWork = new EF.UnitOfWork(context);

            if (repository.Exists(x=>x.UserName== "TestUser"))
            {
                var entities = repository.GetAll().Where(x => x.UserName == "TestUser").ToArray();
                repository.Delete(entities);
                unitOfWork.SaveChanges();
            }
            repository.Insert(user);
            unitOfWork.SaveChanges();

            var data = repository.GetAll().Where(x => x.UserName == "TestUser").ToList();
            Assert.AreEqual(data.Count,1);
        }
    }
}