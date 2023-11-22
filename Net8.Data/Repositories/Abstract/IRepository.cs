using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Net8.Data.Repositories.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllByFilterAsync(Expression<Func<TEntity, bool>> filter = null, params Func<IQueryable<TEntity>, IQueryable<TEntity>>[] includes);
        Task<TEntity> GetFirstByFilterAsync(Expression<Func<TEntity, bool>> filter = null, params Func<IQueryable<TEntity>, IQueryable<TEntity>>[] includes);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entity);
    }
}
