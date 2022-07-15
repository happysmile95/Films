using FilmsCatalog.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog
{
    public interface IUserCacheService
    {
        UserCacheData GetCurrentUserInfo();
        public ConcurrentDictionary<string, UserCacheData> Users { get; }
    }
}
