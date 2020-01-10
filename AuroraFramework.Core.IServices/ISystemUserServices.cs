using AuroraFramework.Core.IServices.Base;
using AuroraFramework.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraFramework.Core.IServices
{
    public interface ISystemUserServices : IBaseServices<SystemUser>
    {
        Task<List<SystemUser>> GetSystemUsers();
    }
}
