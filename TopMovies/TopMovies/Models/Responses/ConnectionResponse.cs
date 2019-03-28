using System;
namespace TopMovies.Models.Responses
{
    public class ConnectionResponse
    {
        public bool IsSuccess
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public object Result
        {
            get;
            set;
        }

    }
}