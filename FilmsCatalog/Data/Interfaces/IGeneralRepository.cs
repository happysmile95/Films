using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FilmsCatalog.Data
{
    public interface IGeneralRepository
    {
        Task<List<T>> GetAsync<T>(Expression<Func<T, bool>> expression, int skip = 0, int take = 0, params string[] includes) where T : BaseEntity;
        Task<T> FindAsync<T>(Expression<Func<T, bool>> expression, params string[] includes) where T : class;
        Task<int> AddAsync<TEntity>(TEntity entity) where TEntity : BaseEntity;
        Task<int> GetCountAsync<TEntity>() where TEntity : BaseEntity;
    }
}
