using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace TopMovies.Views
{
    public partial class MovieDetailView : ContentPage
    {
        #region Attributtes
        private double width = 0;
        private double height = 0;
        #endregion


        public MovieDetailView()
        {
            InitializeComponent();          
        }


        async void ShakeButton_Clicked(object sender, EventArgs e)
        {
            uint timeout = 50;
            await Play.TranslateTo(-15, 0, timeout);
            await Play.TranslateTo(15, 0, timeout);
            await Play.TranslateTo(-10, 0, timeout);
            await Play.TranslateTo(10, 0, timeout);
            await Play.TranslateTo(-5, 0, timeout);
            await Play.TranslateTo(5, 0, timeout);
            Play.TranslationX = 0;


            await imageMovie.TranslateTo(-15, 0, timeout);
            await imageMovie.TranslateTo(15, 0, timeout);
            await imageMovie.TranslateTo(-10, 0, timeout);
            await imageMovie.TranslateTo(10, 0, timeout);
            await imageMovie.TranslateTo(-5, 0, timeout);
            await imageMovie.TranslateTo(5, 0, timeout);
            imageMovie.TranslationX = 0;
        }

        #region Methods
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height); //must be called

            if (this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;

                UpdateLayout();
            }
        }

        void UpdateLayout()
        {
            if (width > height)
            {
                // Landscape;
                ContentView.Margin = new Thickness(0, 0, 0, 0);
                gridChildren.TranslationY = 10;
            }
            else
            {  // Portrait;
                gridChildren.TranslationY = -50;
                ContentView.Margin = new Thickness(0, -70, 0, 0);

            }
        }
        #endregion

    }
}

