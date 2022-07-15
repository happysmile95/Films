using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Data
{
    public interface IFilmRepository : IGeneralRepository
    {
        public Task BulkAdd(List<Film> films);
        public Task BulkUpdate(List<Film> films);
    }
}
