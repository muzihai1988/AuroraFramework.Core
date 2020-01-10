using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuroraFramework.Core.IRepository.Base
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns></returns>
        SqlSugarClient GetDBClient();

        /// <summary>
        /// 开始事务
        /// </summary>
        void BeginTran();

        /// <summary>
        /// 提交事务
        /// </summary>
        void CommitTran();

        /// <summary>
        /// 事务回滚
        /// </summary>
        void RollbackTran();
    }
}
