using System;
using System.Threading.Tasks;
using TopMovies.Base.ViewModels;
using TopMovies.Models;
using TopMovies.Services.Connection;
using TopMovies.Services.Dialog;
using TopMovies.Services.Navigation;

namespace TopMovies.ViewModels
{
    public class MovieDetailViewModel : ViewModelBase
    {

        #region Attributes
        private Movies.Result _selectedMovie;
        public string _title;
        #endregion

        #region Properties
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public Movies.Result SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                OnPropertyChanged();
            }
        }


        public MovieDetailViewModel(IConnectionService connectionService, INavigationService navigationService, IDialogService dialogService)
         : base(connectionService, navigationService, dialogService)
        {
        }

        public override async Task InitializeAsync(object data)
        {

            if (data is Movies.Result)
            {
               
                SelectedMovie = (Movies.Result)data;
                var imageBackdrop = SelectedMovie.Backdrop_path;

            }



        }
    }
}
