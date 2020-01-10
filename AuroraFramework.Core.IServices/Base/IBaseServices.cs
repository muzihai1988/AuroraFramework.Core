using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraFramework.Core.IServices.Base
{
    public interface IBaseServices<TEntity> where TEntity : class
    {
        #region Query
        Task<List<TEntity>> Query();
        Task<TEntity> QueryById(object id);
        Task<List<TEntity>> QueryByIds(object[] ids);
        #endregion

        #region Insert
        Task<int> Insert(TEntity entity);
        #endregion

        #region Update
        Task<bool> Update(TEntity entity);
        #endregion

        #region Delete
        Task<bool> Delete(TEntity entity);
        Task<bool> DeleteById(object id);
        Task<bool> DeleteByIds(object[] ids);
        #endregion
    }
}
