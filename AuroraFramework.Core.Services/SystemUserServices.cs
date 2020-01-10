using AuroraFramework.Core.IRepository;
using AuroraFramework.Core.IServices;
using AuroraFramework.Core.Model;
using AuroraFramework.Core.Services.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuroraFramework.Core.Services
{
    public class SystemUserServices : BaseServices<SystemUser>, ISystemUserServices
    {
        ISystemUserRepository _repository;
        public SystemUserServices(ISystemUserRepository repository)
        {
            this._repository = repository;
            base.BaseRepository = repository;
        }

        public async Task<List<SystemUser>> GetSystemUsers()
        {
            return await _repository.Query();
        }
    }
}
