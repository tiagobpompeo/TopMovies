using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TopMovies.Models;

namespace TopMovies.Services.Details
{
    public interface IDetailMovie
    {
        Task<MovieDetails> GetAllMovieDetailAsync(int movieId);
    }
}
