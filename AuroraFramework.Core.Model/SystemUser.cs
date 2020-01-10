using SqlSugar;
using System;

namespace AuroraFramework.Core.Model
{
    [SugarTable("tb_SystemUser")]
    public class SystemUser
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public string UserID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public bool State { get; set; }
    }
}
