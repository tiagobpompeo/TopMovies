using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TopMoviesTransition.Detail;
using TopMoviesTransition.Models;

namespace TopMoviesTransition.Services.UpComing
{
    public interface IUpComing
    {
        Task<List<Movies.Result>> GetAllMoviesAsync(int page);
        Task<GenreClass> GetAllGenresAsync();
    }
}
