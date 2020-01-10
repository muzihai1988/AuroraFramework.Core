using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace AuroraFramework.Core.API.Extensions
{
    public static class SqlSugarSetup
    {
        public static void UseSqlSugarExtension(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<ISqlSugarClient>(o =>
            {
                var connetionString = "Data Source=DESKTOP-7EBPF2I\\SQLEXPRESS;Initial Catalog=AuroraDB;Persist Security Info=True;User ID=sa;Password=sa";

                return new SqlSugarClient(new ConnectionConfig
                {
                    ConnectionString = connetionString,
                    DbType = DbType.SqlServer,
                    InitKeyType = InitKeyType.Attribute,
                    IsAutoCloseConnection = true
                });
            });
        }
    }
}
