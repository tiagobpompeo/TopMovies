using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Akavache;
using TopMovies.Constants;
using TopMovies.Detail;
using TopMovies.Helpers;
using TopMovies.Models;
using TopMovies.Repository;
using TopMovies.Services.BaseChacheService;

namespace TopMovies.Services.UpComing
{
    public class UpComingService : BaseService, IUpComing
    {
        private readonly IGenericRepository _genericRepository;

        public UpComingService(IGenericRepository genericRepository, IBlobCache cache = null)
        : base(cache)
        {
            _genericRepository = genericRepository;
        }

        public async Task<List<Movies.Result>> GetAllMoviesAsync(int page)
        {
            List<Movies.Result> moviesFromCache = await GetFromCache<List<Movies.Result>>(page.ToString());
            if (moviesFromCache != null)//loaded from cache
            {
                return moviesFromCache;
            }
            else
            {
                string uri = $"{ApiConstants.BaseApiUrl}upcoming?api_key={ApiConstants.Api_key}&language=en-us&page={page}";
                var movies = await _genericRepository.GetAsync<Movies>(uri);
                GeneralVar.TotalPages = movies.Total_pages;//count
                var listMovies = movies.Results;
                Cache.InsertObject(page.ToString(), listMovies, DateTimeOffset.Now.AddSeconds(20));
                return listMovies;
            }      
        }

        public async Task<GenreClass> GetAllGenresAsync()
        {
            var genres = await _genericRepository.GetAsync<GenreClass>(ApiConstants.UrlGenre);
            return genres;
        }
    }
}