using FilmsCatalog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FilmsCatalog.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<int> AddUserAsync(User user)
        {
            _context.Set<User>().Add(user);
            return _context.SaveChangesAsync();
        }

        public Task<User> FindAsync(Expression<Func<User, bool>> expression)
        {
            return _context.Users.Where(expression)
                .OrderBy(e => e.Email)
                .FirstOrDefaultAsync();
        }

        public List<User> Get(Expression<Func<User, bool>> expression)
        {
            return _context.Users
                .Where(expression)
                .ToList();
        }
    }
}
