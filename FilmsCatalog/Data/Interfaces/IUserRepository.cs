using FilmsCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FilmsCatalog.Data
{
    public interface IUserRepository
    {
        List<User> Get(Expression<Func<User, bool>> expression);
        Task<User> FindAsync(Expression<Func<User, bool>> expression);
        Task<int> AddUserAsync(User user);
    }
}
