﻿using System.Runtime.Serialization;

namespace TopMovies.Detail
{
    [DataContract]
    public class Country
    {
        [DataMember(Name = "iso_3166_1")]
        public string Iso3166Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}