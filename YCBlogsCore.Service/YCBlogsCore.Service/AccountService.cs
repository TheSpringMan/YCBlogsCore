using System;
using System.Collections.Generic;
using System.Text;
using YCBlogsCore.Data;
using YCBlogsCore.Data.Repository;

namespace YCBlogsCore.Service
{
    public interface IAccountService
    {

    }

    public class AccountService:IAccountService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;

        public AccountService(IUnitOfWork unitOfWork, IUserRepository user)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = user;
        }

    }
}
