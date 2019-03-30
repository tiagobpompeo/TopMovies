using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace TopMovies.Models
{
    public class Movies
    {

        [JsonProperty(PropertyName = "results")]
        public List<Result> Results { get; set; }
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }
        [JsonProperty(PropertyName = "total_results")]
        public int Total_results { get; set; }
        [JsonProperty(PropertyName = "dates")]
        public Datess Dates { get; set; }
        [JsonProperty(PropertyName = "total_pages")]
        public int Total_pages { get; set; }



        public class Result
        {
            [JsonProperty(PropertyName = "vote_count")]
            public int Vote_count { get; set; }
            [JsonProperty(PropertyName = "id")]
            public int Id { get; set; }
            [JsonProperty(PropertyName = "video")]
            public bool Video { get; set; }
            [JsonProperty(PropertyName = "vote_average")]
            public double Vote_average { get; set; }
            [JsonProperty(PropertyName = "title")]
            public string Title { get; set; }
            [JsonProperty(PropertyName = "popularity")]
            public double Popularity { get; set; }
            [JsonProperty(PropertyName = "poster_path")]
            public string Poster_path { get; set; }
            [JsonProperty(PropertyName = "original_language")]
            public string Original_language { get; set; }
            [JsonProperty(PropertyName = "original_title")]
            public string Original_title { get; set; }
            [JsonProperty(PropertyName = "genre_ids")]
            public List<int> Genre_ids { get; set; }
            [JsonProperty(PropertyName = "backdrop_path")]
            public string Backdrop_path { get; set; }
            [JsonProperty(PropertyName = "adult")]
            public bool Adult { get; set; }
            [JsonProperty(PropertyName = "overview")]
            public string Overview { get; set; }
            [JsonProperty(PropertyName = "release_date")]
            public string Release_date { get; set; }   
                    
        }

        public class Datess
        {
            [JsonProperty(PropertyName = "maximum")]
            public string Maximum { get; set; }
            [JsonProperty(PropertyName = "minimum")]
            public string Minimum { get; set; }
        }
    }
}