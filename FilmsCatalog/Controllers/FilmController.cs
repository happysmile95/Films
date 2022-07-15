using FilmsCatalog.Models;
using FilmsCatalog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FilmsCatalog.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;
        private readonly IUserCacheService _userCacheService;
        public FilmController(IFilmService filmService, IUserCacheService userCacheService)
        {
            _filmService = filmService;
            _userCacheService = userCacheService;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAllFilms(int page = 1)
        {
            var films = await _filmService.GetFilms(page);
            return View(films);
        }

        [HttpGet]
        public async Task<IActionResult> GetFilmInfo(long filmId)
        {
            var filmInfo = await _filmService.GetFilm(filmId);
            return View(filmInfo);
        }

        [HttpPost]
        public async Task<IActionResult> EditFilm(FilmViewModel model, string action)
        {
            if (action == "edit")
            {
                var filmInfo = await _filmService.GetFilm(model.FilmId);
                return View("EditFilmView", filmInfo);
            }
            else
            {
                var user = _userCacheService.GetCurrentUserInfo();
                return View("AddFilmView", new FilmViewModel() { UserName = user.UserName });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Save(FilmViewModel model)
        {
            var file = HttpContext.Request.Form.Files.Count > 0 ? HttpContext.Request.Form.Files[0] : null;
            if (file != null)
            {
                using (var target = new MemoryStream())
                {
                    file.CopyTo(target);
                    model.Image = target.ToArray();
                }
            }
            
            var filmNew = await _filmService.AddNewFilm(model);
            return View("GetFilmInfo", filmNew);
        }
        
        [HttpPost]
        public IActionResult AddFilm()
        {
            var user = _userCacheService.GetCurrentUserInfo();
            return View("AddFilmView", new FilmViewModel() { UserName = user.UserName, UserId = user.Id });
        }
    }
}
