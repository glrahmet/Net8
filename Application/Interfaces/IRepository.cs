using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task Update(T entity);
        Task Delete(T entity);

      //  Task<IQueryable<T> Include(Func<IQueryable<T>, IQueryable<T, object>> include);

      //  Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        //Task<T> GetFirstByFilterAsync(Expression<Func<T, bool>> filter = null, params Func<IQueryable<T>, IQueryable<T>>[] includes);
    }
}
