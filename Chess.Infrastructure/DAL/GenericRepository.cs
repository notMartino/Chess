using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Infrastructure.DAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _db;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _db = dbContext.Set<T>();
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if (expression != null)
                query = query.Where(expression);

            if (includes != null)
                foreach (var property in includes)
                {
                    query = query.Include(property);
                }

            if (orderBy != null)
                query = orderBy(query);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if (includes != null)
                foreach (var property in includes)
                {
                    query = query.Include(property);
                }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task Put(T entity)
        {
             await _db.AddAsync(entity);
        }

        public async Task PutRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<bool> Delete(long id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);

            return true;
        }

        public Task<bool> DeleteRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
