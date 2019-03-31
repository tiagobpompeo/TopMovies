using System;
using System.Collections.Generic;

namespace TopMovies.Models
{
    public class GenreClass
    {
        public List<Genre> genres { get; set; }

        public class Genre
        {
            public int id { get; set; }
            public string name { get; set; }
        }

    }
}
