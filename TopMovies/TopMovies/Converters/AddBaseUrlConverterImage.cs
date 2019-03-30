using System;
using Xamarin.Forms;

namespace TopMovies.Converters
{
    public class AddBaseUrlConverterImageSmall : IValueConverter
    {

        #region IValueConverter implementation

        private const string BaseUrlImageSmall = "https://image.tmdb.org/t/p/w200/";

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string && !string.IsNullOrEmpty((string)value))
            {

                return string.Format("{0}{1}", BaseUrlImageSmall, (string)value);
            }
            return ""; // 
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
