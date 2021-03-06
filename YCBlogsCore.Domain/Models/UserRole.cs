﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YCBlogsCore.Domain.Models
{
    public class UserRole
    {
        public Int32 UserId { get; set; }
        public virtual User User { get; set; }

        public Int32 RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
