using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace TopMovies.Views
{
    public partial class MovieDetailView : ContentPage
    {


        private double width = 0;
        private double height = 0;

        public MovieDetailView()
        {
            InitializeComponent();
        }

               
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
                imageMovie.Aspect = Aspect.AspectFill;
                imageMovie.Margin = new Thickness(0, 0, 0, 0);
            }
            else
            {  // Portrait;
                imageMovie.Aspect = Aspect.AspectFit;
                imageMovie.Margin = new Thickness(0, -120, 0, 0);

            }
        }
    }
}

