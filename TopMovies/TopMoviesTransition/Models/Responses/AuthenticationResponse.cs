using System;
namespace TopMoviesTransition.Models.Responses
{
    public class AuthenticationResponse
    {
        public bool IsAuthenticated { get; set; }
        public User User { get; set; }
    }
}
