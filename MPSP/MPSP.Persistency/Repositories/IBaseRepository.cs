using System;
using System.Collections.Generic;

namespace MPSP.Persistency.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class 
    {
        TEntity Add(TEntity obj);
        int AddRange(IEnumerable<TEntity> entities);
        TEntity GetById(object id);
        IEnumerable<TEntity> GetAll();
        int Update(TEntity obj);
        int UpdateRange(IEnumerable<TEntity> entities);
        bool Remove(object id);
        int Remove(TEntity obj);
        int RemoveRange(IEnumerable<TEntity> entities);
    }
}
