using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Diagnostics;
using YCBlogsCore.Utils;

namespace YCBlogsCore.Data.EF
{
    public class CustomDbCommandInterceptor:DbCommandInterceptor
    {
        public override void CommandFailed(DbCommand command, CommandErrorEventData eventData)
        {
            LogErrorSQL(command, eventData);
            base.CommandFailed(command, eventData);
        }

        public override Task CommandFailedAsync(DbCommand command, CommandErrorEventData eventData, CancellationToken cancellationToken = default)
        {
            LogErrorSQL(command, eventData);
            return base.CommandFailedAsync(command, eventData, cancellationToken);
        }

        public override ValueTask<DbDataReader> ReaderExecutedAsync(DbCommand command, CommandExecutedEventData eventData, DbDataReader result, CancellationToken cancellationToken = default)
        {
            LogExecutionTime(command, eventData.Duration.TotalSeconds);
            return base.ReaderExecutedAsync(command, eventData, result, cancellationToken);
        }

        public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            LogExecutionTime(command, eventData.Duration.TotalSeconds);
            return base.ReaderExecuted(command, eventData, result);
        }

        public override object ScalarExecuted(DbCommand command, CommandExecutedEventData eventData, object result)
        {
            LogExecutionTime(command, eventData.Duration.TotalSeconds);
            return base.ScalarExecuted(command, eventData, result);
        }

        public override ValueTask<object> ScalarExecutedAsync(DbCommand command, CommandExecutedEventData eventData, object result, CancellationToken cancellationToken = default)
        {
            LogExecutionTime(command, eventData.Duration.TotalSeconds);
            return base.ScalarExecutedAsync(command, eventData, result, cancellationToken);
        }

        public override ValueTask<int> NonQueryExecutedAsync(DbCommand command, CommandExecutedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            LogExecutionTime(command, eventData.Duration.TotalSeconds);
            return base.NonQueryExecutedAsync(command, eventData, result, cancellationToken);
        }

        public override int NonQueryExecuted(DbCommand command, CommandExecutedEventData eventData, int result)
        {
            LogExecutionTime(command, eventData.Duration.TotalSeconds);
            return base.NonQueryExecuted(command, eventData, result);
        }


        private void LogErrorSQL(DbCommand command, CommandErrorEventData eventData)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(command.CommandText);
            if (command.Parameters.Count > 0)
            {
                sb.Append("参数：");
                foreach (SqlParameter item in command.Parameters)
                {
                    sb.AppendFormat("{0}:{1},\t{2},\t", item.ParameterName, item.Value, item.DbType.GetType());
                }
            }
            LogHelper.Error(sb.ToString(), eventData.Exception);
        }

        private void LogExecutionTime(DbCommand command, double executionSeconds)
        {
            if (executionSeconds > GlobalContext.DbConfig.DBSlowSqlLogTime)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("耗时SQL如下，用时：" + executionSeconds + "秒");
                sb.AppendLine(command.CommandText);
                if (command.Parameters.Count > 0)
                {
                    sb.Append("参数：");
                    foreach (SqlParameter item in command.Parameters)
                    {
                        sb.AppendFormat("{0}:{1},\t{2},\t", item.ParameterName, item.Value, item.DbType.GetType());
                    }
                }
                LogHelper.Warn(sb.ToString());
            }
        }


    }
}
