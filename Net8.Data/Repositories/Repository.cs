using Microsoft.EntityFrameworkCore;
using Net8.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Net8.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _context;
        protected DbSet<TEntity> _dbSet;
        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAllByFilterAsync(Expression<Func<TEntity, bool>> filter = null, params Func<IQueryable<TEntity>, IQueryable<TEntity>>[] includes)
        {
            var query = _dbSet.AsQueryable();
            foreach (var include in includes)
            {
                query = include(query);
            }

            return filter == null ? await query.ToListAsync() : await query.Where(filter).ToListAsync();
        }
        public async Task<TEntity> GetFirstByFilterAsync(Expression<Func<TEntity, bool>> filter = null, params Func<IQueryable<TEntity>, IQueryable<TEntity>>[] includes)
        {
            var query = _dbSet.AsQueryable();
            foreach (var include in includes)
            {
                query = include(query);
            }

            return filter == null ? await query.FirstOrDefaultAsync() : await query.Where(filter).FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entity)
        {
            _dbSet.UpdateRange(entity);
        }
    }
}
