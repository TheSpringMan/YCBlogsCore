using System;
using System.Collections.Generic;
using System.Text;

namespace YCBlogsCore.Domain.Models
{
    public class User:EntityBase<Int32>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string MobilePhone { get; set; }

        public string Remark { get; set; }

        public virtual IList<UserRole>  UserRoles { get; set; }
    }
}
