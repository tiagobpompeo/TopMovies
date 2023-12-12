using System;
using System.Threading.Tasks;
using Akavache;

namespace TopMoviesTransition.Services.BaseChacheService
{
    public interface IBaseService
    {
        Task<T> GetFromCache<T>(string cacheName);
        void InvalidateCache();
    }
}
