using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;
using static TopMovies.Models.GenreClass;

namespace TopMovies.Converters
{
    public class GenresTextConverterOn : IValueConverter
    {
        List<int> idMovies;


        public object Convert(object genresIds, Type targetType, object parameter, CultureInfo culture)
        {
            var ids = genresIds as List<int>;

            if (ids.Count!= 0) 
            {
                idMovies = genresIds as List<int>;
            }
            else 
            {
                idMovies.Add(9);
            }


            switch (idMovies[0])
            {
                case 28:
                    return "Action";
                case 12:
                    return "Adventure";
                case 16:
                    return "Animation";
                case 35:
                    return "Comedy";
                case 80:
                    return "Crime";
                case 99:
                    return "Documentary";
                case 18:
                    return "Drama";
                case 37:
                    return "Western";
                case 10751:
                    return "Family";
                case 14:
                    return "Fantasy";
                case 36:
                    return "History";
                case 27:
                    return "Horror";
                case 10402:
                    return "Music";
                case 9648:
                    return "Mistery";
                case 10749:
                    return "Romance";
                case 878:
                    return "Science Fiction";
                case 10770:
                    return "Tv Movie";
                case 53:
                    return "Thriller";
                case 10752:
                    return "War";
                case 9:
                    return "";
                default:
                    return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Not needed here
            throw new NotImplementedException();
        } 
    }
}
