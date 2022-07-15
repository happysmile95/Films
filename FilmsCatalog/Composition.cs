using FilmsCatalog.Data;
using FilmsCatalog.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog
{
    public static class Composition
    {
        private static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IFilmService, FilmService>();
        }

        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGeneralRepository, GeneralRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserCacheService, UserCacheService>();
        }

        public static void RegisterDependency(this IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterServices(services);
        }
    }
}
