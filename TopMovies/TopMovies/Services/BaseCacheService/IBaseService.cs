using System;
using System.Threading.Tasks;
using Akavache;

namespace TopMovies.Services.BaseChacheService
{
    public interface IBaseService
    {
        Task<T> GetFromCache<T>(string cacheName);
        void InvalidateCache();
    }
}
