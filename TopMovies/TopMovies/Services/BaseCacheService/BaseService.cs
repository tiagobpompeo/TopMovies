using Akavache;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reactive.Linq;//importante essa Biblioteca
using TopMovies.Models;
using System;

namespace TopMovies.Services.BaseChacheService
{
    public class BaseService
    {
        protected IBlobCache Cache;

        public BaseService()
        {
            Cache = BlobCache.LocalMachine;

        }

        public BaseService(IBlobCache cache)
        {
            Cache = cache ?? BlobCache.LocalMachine;
        }

        public async Task<T> GetFromCache<T>(string cacheName)
        {
            try
            {
                T t = await Cache.GetObject<T>(cacheName);
                return t;
            }
            catch (KeyNotFoundException)
            {
                return default(T);
            }
        }

        public async Task InsertObject<T>(string key, T value, System.DateTimeOffset dateTimeOffset)
        {
            await Cache.InsertObject(key, value, dateTimeOffset);
        }


        public void InvalidateCache(string key)
        {
            Cache.Invalidate(key);
        }


        public async Task InsertObjectNoTimeCache<T>(string key, T value)
        {
            await Cache.InsertObject(key, value);
        }

        public async Task InsertObjecItemsCache(Dictionary<string, string> dicionarioTodo)
        {
            await Cache.InsertObjects(dicionarioTodo);
        }
    }
}
