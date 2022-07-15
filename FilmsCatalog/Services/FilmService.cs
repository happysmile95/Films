using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmsCatalog.Data;
using FilmsCatalog.Models;

namespace FilmsCatalog.Services
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IUserCacheService _userCacheService;

        private readonly IMapper _mapper;
        public FilmService(IFilmRepository filmRepository, IMapper mapper, IUserCacheService userCacheService)
        {
            _filmRepository = filmRepository;
            _userCacheService = userCacheService;
            _mapper = mapper;
        }

        public async Task<FilmViewModel> AddNewFilm(FilmViewModel model)
        {
            var exist = await _filmRepository.FindAsync<Film>(e => e.Id == model.FilmId);
            if (exist != null)
                return await UpdateFilm(model);
            var userInfo = _userCacheService.GetCurrentUserInfo();
            if (userInfo == null)
                return new FilmViewModel();
            model.UserId = userInfo.Id;
            model.UserName = userInfo.UserName;
            var entity = _mapper.Map<Film>(model);
            await _filmRepository.AddAsync(entity);
            model = _mapper.Map<FilmViewModel>(entity);
            model.UserName = userInfo.UserName;
            return model;
        }

        public async Task<FilmViewModel> GetFilm(long filmId)
        {
            var film = await _filmRepository.FindAsync<Film>(e => e.Id == filmId);
            var userInfo = _userCacheService.GetCurrentUserInfo();
            var model = _mapper.Map<FilmViewModel>(film);
            model.UserId = _userCacheService.Users.FirstOrDefault(e => e.Value.Id == model.UserId).Value.Id;
            model.UserName = _userCacheService.Users.FirstOrDefault(e => e.Value.Id == model.UserId).Value.UserName;
            model.Disabled = model.UserId != userInfo.Id;
            return model;
        }

        public async Task<FilmsPageViewModel> GetFilms(int page = 1, int take = 3)
        {
            var user = _userCacheService.GetCurrentUserInfo();
            if (user == null)
                return new FilmsPageViewModel();
            var skip = (page - 1) * take;
            var films = await _filmRepository.GetAsync<Film>(e => !e.IsDeleted, skip: skip, take: take);
            
            var filmsCount = await _filmRepository.GetCountAsync<Film>();
            var pageViewModel = new PageViewModel(filmsCount, page, take);
            var filmsView = _mapper.Map<List<FilmViewModel>>(films);
            filmsView.ForEach(f =>
            {
                f.UserName = _userCacheService.Users.FirstOrDefault(e => e.Value.Id == f.UserId).Key;
                f.Disabled = f.UserName != user.UserName;
            });
            return new FilmsPageViewModel
            {
                PageViewModel = pageViewModel,
                Films = filmsView,
                Enabled = user != null
            };
        }

        public async Task<FilmViewModel> UpdateFilm(FilmViewModel filmViewModel)
        {
            var user = _userCacheService.GetCurrentUserInfo();
            filmViewModel.UserName = user.UserName;
            filmViewModel.UserId = user.Id;
            var filmEntity = _mapper.Map<Film>(filmViewModel);
            await _filmRepository.BulkUpdate(new List<Film>() { filmEntity });
            
            var model = _mapper.Map<FilmViewModel>(filmEntity);
            model.UserName = user.UserName;
            return model;
        }
    }
}