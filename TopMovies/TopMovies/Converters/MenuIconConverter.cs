using System;
using System.Globalization;
using TopMovies.Enumerations;
using Xamarin.Forms;

namespace TopMovies.Converters
{
    public class MenuIconConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (MenuItemType) value;

            switch (type)
            {
                case MenuItemType.MainPage:
                    return "homeS.svg";               

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
