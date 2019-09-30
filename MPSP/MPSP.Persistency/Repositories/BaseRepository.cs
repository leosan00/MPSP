using Microsoft.EntityFrameworkCore;
using MPSP.Persistency.Context;
using System;
using System.Collections.Generic;

namespace MPSP.Persistency.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

        protected readonly MPSPSearchContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(MPSPSearchContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = this._dbContext.Set<TEntity>();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public TEntity Add(TEntity obj)
        {
            var r = _dbSet.Add(obj);
            Commit();
            return r.Entity;
        }

        public int AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRangeAsync(entities);
            return Commit();
        }


        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public bool Remove(object id)
        {
            TEntity entity = GetById(id);

            if (entity == null) return false;

            return Remove(entity) > 0 ? true : false;
        }

        public int Remove(TEntity obj)
        {
            _dbSet.Remove(obj);
            return Commit();
        }

        public int RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            return Commit();
        }

        public int Update(TEntity obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            return Commit();
        }

        public int UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
            return Commit();
        }

        private int Commit()
        {
            return _dbContext.SaveChanges();
        }
    }
}
