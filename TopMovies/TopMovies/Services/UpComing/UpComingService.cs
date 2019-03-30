using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Akavache;
using TopMovies.Constants;
using TopMovies.Models;
using TopMovies.Repository;
using TopMovies.Services.BaseChacheService;

namespace TopMovies.Services.UpComing
{
    public class UpComingService : BaseService,IUpComing
    {
        private readonly IGenericRepository _genericRepository;


        public UpComingService(IGenericRepository genericRepository, IBlobCache cache = null) 
        : base(cache)
        {
            _genericRepository = genericRepository;
        }

        public async Task<List<Movies.Result>> GetAllMoviesAsync(int page)
        {
            var movies = await _genericRepository.GetAsync<Movies>
            (ApiConstants.UpComingEndPointComplete + page.ToString());           
            var listMovies = movies.Results;

            return listMovies;
        }     
    }
}