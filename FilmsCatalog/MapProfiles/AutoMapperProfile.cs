using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmsCatalog.Data;
using FilmsCatalog.Models;

namespace FilmsCatalog.MapProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Film, FilmViewModel>()
                .ForMember(dest => dest.FilmId, p => p.MapFrom(e => e.Id))
                .ForMember(dest => dest.UserId, p => p.MapFrom(e => e.UserId));
            CreateMap<FilmViewModel, Film>()
                .ForMember(dest => dest.Id, p => p.MapFrom(e => e.FilmId))
                .ForMember(dest => dest.UserId, p => p.MapFrom(e => e.UserId));
        }
    }
}
