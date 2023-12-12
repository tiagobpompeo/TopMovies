using System;
using System.Threading.Tasks;
using TopMoviesTransition.Models.Responses;

namespace TopMoviesTransition.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Register(string firstName, string lastName, string email, string userName,
            string password);

        Task<AuthenticationResponse> Authenticate(string userName, string password);

        bool IsUserAuthenticated();
    }
}
