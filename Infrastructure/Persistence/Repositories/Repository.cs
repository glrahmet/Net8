using Application.Interfaces;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly Net8Context _context;
        public Repository(Net8Context context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<T> GetFirstByFilterAsync(Expression<Func<T, bool>> filter = null, params Func<IQueryable<T>, IQueryable<T>>[] includes)
        {

            var query = _context.Set<T>().AsQueryable();
            foreach (var include in includes)
            {
                query = include(query);
            }

            return filter == null ? await query.FirstOrDefaultAsync() : await query.Where(filter).FirstOrDefaultAsync();
        }

        public Task<IEnumerable<T>> GetAllByFilterAsync(Expression<Func<T, bool>> filter = null, params Func<IQueryable<T>, IQueryable<T>>[] includes)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,   string includeProperties = "")
        //{
        //    IQueryable<T> Query = _context.Set<T>();

        //    if (filter != null)
        //    {
        //        Query = Query.Where(filter);
        //    }

        //    if (!string.IsNullOrEmpty(includeProperties))
        //    {
        //        foreach (string IncludeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            Query = Query.Include(IncludeProperty);
        //        }
        //    }

        //    return Query;
        //}
    }
}
