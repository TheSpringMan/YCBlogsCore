using System;
using System.Collections.Generic;
using System.Text;

namespace YCBlogsCore.Domain.Models
{
    public class Role:EntityBase<Int32>
    {
        public string RoleName { get; set; }

        public virtual IList<UserRole> UserRoles { get; set; }

    }
}
