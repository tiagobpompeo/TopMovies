using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Akavache;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using TopMoviesTransition.Constants;
using TopMoviesTransition.Detail;
using TopMoviesTransition.Helpers;
using TopMoviesTransition.Models;
using TopMoviesTransition.Repository;
using TopMoviesTransition.Services.BaseChacheService;

namespace TopMoviesTransition.Services.UpComing
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
            //Analytics.TrackEvent("Evento Teste");
            //Exception exception = new Exception();
            //var properties = new Dictionary<string, string> {
            //    { "Category", "Music" },
            //    { "Wifi", "On" }
            //  };
            //Crashes.TrackError( exception, properties);
            //Crashes.GenerateTestCrash();

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