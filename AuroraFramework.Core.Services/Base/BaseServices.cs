using AuroraFramework.Core.IRepository.Base;
using AuroraFramework.Core.IServices.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuroraFramework.Core.Services.Base
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class, new()
    {
        public IBaseRepository<TEntity> BaseRepository;

        public async Task<bool> Delete(TEntity entity)
        {
            return await BaseRepository.Delete(entity);
        }

        public async Task<bool> DeleteById(object id)
        {
            return await BaseRepository.DeleteById(id);
        }

        public async Task<bool> DeleteByIds(object[] ids)
        {
            return await BaseRepository.DeleteByIds(ids);
        }

        public async Task<int> Insert(TEntity entity)
        {
            return await BaseRepository.Insert(entity);
        }

        public async Task<TEntity> QueryById(object id)
        {
            return await BaseRepository.QueryById(id);
        }

        public async Task<List<TEntity>> QueryByIds(object[] ids)
        {
            return await BaseRepository.QueryByIds(ids);
        }

        public async Task<bool> Update(TEntity entity)
        {
            return await BaseRepository.Update(entity);
        }

        public async Task<List<TEntity>> Query()
        {
            return await BaseRepository.Query();
        }
    }
}
