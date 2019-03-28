﻿using System;
namespace TopMovies.Models.Requests
{
    public class AuthenticationRequest
    {
        public string Password { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
