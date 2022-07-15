using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FilmsCatalog.Data
{
    public class GeneralRepository : IGeneralRepository
    {
        protected readonly CoreContext _context;
        public GeneralRepository(CoreContext context)
        {
            _context = context;
        }

        public Task<int> AddAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _context.Add(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<T> FindAsync<T>(Expression<Func<T, bool>> expression, params string[] includes) where T : class
        {
            var query = Include<T>(_context.Set<T>(), includes);
            return await query.FirstOrDefaultAsync(expression);
        }
        
        public async Task<List<T>> GetAsync<T>(Expression<Func<T, bool>> expression, int skip = 0, int take = 0, params string[] includes) where T : BaseEntity
        {
            var query = _context.Set<T>()
                .Where(expression)
                .OrderBy(e => e.CreatedDate)
                .Skip(skip);
            Include<T>(query, includes);
            if (take > 1)
                return await query.Take(take).ToListAsync();
            return await query.ToListAsync();
        }

        public Task<int> GetCountAsync<TEntity>() where TEntity : BaseEntity
        {
            return _context.Set<TEntity>().CountAsync();
        }

        private IQueryable<T> Include<T>(IQueryable<T> query, params string[] includes) where T : class
        {
            if (includes != null && includes.Any())
            {
                foreach (var property in includes)
                {
                    query = query.Include(property);
                }
            }
            return query;
        }
    }
}
