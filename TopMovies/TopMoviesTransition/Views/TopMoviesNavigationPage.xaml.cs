using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TopMovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopMoviesNavigationPage : NavigationPage
    {
        public TopMoviesNavigationPage()
        {
            InitializeComponent();
            //BarBackgroundColor = Color.FromHex("#602040");
            //BarTextColor = Color.White;
        }

        public TopMoviesNavigationPage(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}