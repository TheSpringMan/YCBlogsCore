using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace YCBlogsCore.Utils
{
    public class LogHelper
    {
        private static ILog log = LogManager.GetLogger("YCBlogsCore");

        public static void Info(string message)
        {
            log.Info(message);
        }

        public static void Info(string message, Exception ex)
        {
            log.Info(message, ex);
        }

        public static void Error(string message)
        {
            log.Error(message);
        }
        public static void Error(string message, Exception ex)
        {
            log.Error(message, ex);
        }
        public static void Warn(string message)
        {
            log.Warn(message);
        }
        public static void Warn(string message, Exception ex)
        {
            log.Warn(message, ex);
        }
    }
}
