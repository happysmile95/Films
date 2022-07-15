using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmsCatalog.Models;

namespace FilmsCatalog.Services
{
    public interface IFilmService
    {
        Task<FilmViewModel> AddNewFilm(FilmViewModel model);
        Task<FilmsPageViewModel> GetFilms(int page = 0, int take = 3);
        Task<FilmViewModel> GetFilm(long filmId);
        Task<FilmViewModel> UpdateFilm(FilmViewModel filmViewModel);
    }
}
