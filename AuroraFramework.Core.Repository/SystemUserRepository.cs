using AuroraFramework.Core.IRepository;
using AuroraFramework.Core.IRepository.Base;
using AuroraFramework.Core.Model;
using AuroraFramework.Core.Repository.Base;
using System;

namespace AuroraFramework.Core.Repository
{
    public class SystemUserRepository : BaseRepository<SystemUser>, ISystemUserRepository
    {
        public SystemUserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
