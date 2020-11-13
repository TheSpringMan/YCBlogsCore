using System;
using System.Collections.Generic;
using System.Text;

namespace YCBlogsCore.Domain
{
    public class EntityBase<TPrimaryKey> where TPrimaryKey:struct
    {
        public EntityBase()
        {
            this.CreateTime = DateTime.Now;
            this.IsActived = true;
        }

        public TPrimaryKey Id { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsActived { get; set; }


    }
}
