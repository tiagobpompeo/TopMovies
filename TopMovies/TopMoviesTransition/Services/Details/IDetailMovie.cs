using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TopMoviesTransition.Models;

namespace TopMoviesTransition.Services.Details
{
    public interface IDetailMovie
    {
        Task<MovieDetails> GetAllMovieDetailAsync(int movieId);
    }
}
