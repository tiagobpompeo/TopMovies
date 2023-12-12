using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Akavache;
using TopMoviesTransition.Constants;
using TopMoviesTransition.Models;
using TopMoviesTransition.Repository;
using TopMoviesTransition.Services.BaseChacheService;

namespace TopMoviesTransition.Services.Details
{
    public class MovieDetailService : BaseService, IDetailMovie
    {
        private readonly IGenericRepository _genericRepository;

        public MovieDetailService(IGenericRepository genericRepository, IBlobCache cache = null)
        : base(cache)
        {
            _genericRepository = genericRepository;
        }

        public async Task<MovieDetails> GetAllMovieDetailAsync(int movieId)
        {
            MovieDetails movieDetailFromCache = await GetFromCache<MovieDetails>(movieId.ToString());

            if (movieDetailFromCache != null)//loaded from cache
            {
                return movieDetailFromCache;
            }
            else
            {
                string uri = $"{ApiConstants.DetailMovieBaseUrl}movie/{movieId}?api_key={ApiConstants.Api_key}&language=en-US";
                MovieDetails response = await _genericRepository.GetAsync<MovieDetails>(uri);
                Cache.InsertObject(movieId.ToString(), response, DateTimeOffset.Now.AddSeconds(20));
                return response;
            }
        }

    }
}
