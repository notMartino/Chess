using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Infrastructure.DAL
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null);

        Task<T> Get(Expression<Func<T, bool>> expression = null, List<string> includes = null);

        Task Put(T entity);
        Task PutRange(IEnumerable<T> entities);

        void Update(T entity);

        Task<T> Delete(T entity);
        Task<bool> DeleteRange(IEnumerable<T> entities);
    }
}
