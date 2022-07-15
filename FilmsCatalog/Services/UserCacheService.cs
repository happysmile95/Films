using FilmsCatalog.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace FilmsCatalog.Services
{
    public class UserCacheService : IUserCacheService
    {
        private static ConcurrentDictionary<string, UserCacheData> _usersDictionary = new ConcurrentDictionary<string, UserCacheData>();
        public ConcurrentDictionary<string, UserCacheData> Users 
        {
            get
            {
                return _usersDictionary;
            }
        }
        private readonly IHttpContextAccessor _httpContext;
        private readonly IUserRepository _userRepository;
        public UserCacheService(IHttpContextAccessor httpContext, IUserRepository userRepository)
        {
            _httpContext = httpContext;
            _userRepository = userRepository;
            GetUsers();
        }
        public UserCacheData GetCurrentUserInfo()
        {
            var context = _httpContext.HttpContext;
            if (!(context.User?.Identity?.IsAuthenticated ?? false))
                return null;

            var userName = context.User.Identity.Name;
            if (!_usersDictionary.ContainsKey(userName) || _usersDictionary[userName].ValidTo < DateTime.UtcNow)
                _usersDictionary[userName] = new UserCacheData { ValidTo = DateTime.UtcNow.AddHours(2), UserName = userName, Id = _usersDictionary.ContainsKey(userName) ? _usersDictionary[userName].Id : null };

            return _usersDictionary[userName];
        }

        private void GetUsers()
        {
            var users = _userRepository.Get(e => true);
            foreach (var user in users)
                _usersDictionary.TryAdd(user.UserName, new UserCacheData { ValidTo = DateTime.Now.AddHours(2), UserName = user.UserName, Id = user.Id, Token = Guid.NewGuid().ToString() });
        }
    }

    public class UserCacheData
    {
        public DateTime ValidTo { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Id { get; set; }
    }
}
