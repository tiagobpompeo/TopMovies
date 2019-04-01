using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TopMovies.Models;
using TopMovies.Services.UpComing;

namespace TopMovies.UITests.Mocks
{
    public class MockUpComingService : IUpComing
    {

        private readonly List<Movies.Result> mockMovies = new List<Movies.Result>()
        {
            new Movies.Result 
            {
                Vote_count=268,
                Id = 396461,
                Title = "Under the Silver Lake",
                Original_language="en",
                Original_title = "Under the Silver Lake",
                Release_date= DateTime.Now,
                Backdrop_path="https://image.tmdb.org/t/p/w200/lPTXeEGVtHFBWSe7NXKPyinY1gi.jpg",
                Adult = false,
                Overview="Young and disenchanted Sam meets a mysterious and beautiful woman who's swimming in his building's pool one night. When she suddenly vanishes the next morning, Sam embarks on a surreal quest across Los Angeles to decode the secret behind her disappearance, leading him into the murkiest depths of mystery, scandal and conspiracy."

            },
            new Movies.Result
            {
                Vote_count=269,
                Id = 396464,
                Title = "Under the Silver Lake",
                Original_language="en",
                Original_title = "Under the Silver Lake",
                Release_date= DateTime.Now,
                Backdrop_path="https://image.tmdb.org/t/p/w200/lPTXeEGVtHFBWSe7NXKPyinY1gi.jpg",
                Adult = false,
                Overview="Young and disenchanted Sam meets a mysterious and beautiful woman who's swimming in his building's pool one night. When she suddenly vanishes the next morning, Sam embarks on a surreal quest across Los Angeles to decode the secret behind her disappearance, leading him into the murkiest depths of mystery, scandal and conspiracy."
            }
        };

        public Task<GenreClass> GetAllGenresAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Movies.Result>> GetAllMoviesAsync(int page)
        {
            return Task.FromResult(mockMovies);
        }
    }
}
