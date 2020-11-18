using System;
using System.Collections.Generic;
using System.Text;

namespace YCBlogsCore.Utils.Models
{
    public class DbConfigSetting
    {
        public string DbProvider { get; set; }

        public string ConnectionString { get; set; }
        public int DbCommandTimeout { get; set; }

        public int DBSlowSqlLogTime { get; set; }
    }
}
