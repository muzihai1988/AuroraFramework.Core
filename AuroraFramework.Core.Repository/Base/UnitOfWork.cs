using AuroraFramework.Core.IRepository.Base;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuroraFramework.Core.Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISqlSugarClient _sqlSugarClient;

        public UnitOfWork(ISqlSugarClient sqlSugarClient)
        {
            _sqlSugarClient = sqlSugarClient;
        }

        /// <summary>
        /// 获取db连接，保证唯一性
        /// </summary>
        /// <returns></returns>
        public SqlSugarClient GetDBClient()
        {
            return _sqlSugarClient as SqlSugarClient;
        }

        public void BeginTran()
        {
            GetDBClient().BeginTran();
        }

        public void CommitTran()
        {
            try
            {
                GetDBClient().CommitTran();
            }
            catch (Exception)
            {
                GetDBClient().RollbackTran();
                throw;
            }
        }

        public void RollbackTran()
        {
            GetDBClient().RollbackTran();
        }
    }
}
