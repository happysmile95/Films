using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.BulkExtensions;

namespace FilmsCatalog.Data
{
    public class FilmRepository : GeneralRepository, IFilmRepository
    {
        public FilmRepository(CoreContext context)
            : base(context)
        {
        }

        public Task BulkAdd(List<Film> films)
        {
            return _context.BulkInsertAsync<Film>(films);
        }

        public Task BulkUpdate(List<Film> films)
        {
            return _context.BulkUpdateAsync(films);
        }
    }
}
