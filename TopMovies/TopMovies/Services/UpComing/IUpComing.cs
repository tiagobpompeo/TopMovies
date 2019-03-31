using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TopMovies.Detail;
using TopMovies.Models;

namespace TopMovies.Services.UpComing
{
    public interface IUpComing
    {
        Task<List<Movies.Result>> GetAllMoviesAsync(int page);
        Task<GenreClass> GetAllGenresAsync();
    }
}
