using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TopMovies.Extensions
{
    public static class ListExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> list)
        {
            var collection = new ObservableCollection<T>();
            foreach (var item in list)
            {
                collection.Add(item);
            }

            return collection;
        }
    }
}
