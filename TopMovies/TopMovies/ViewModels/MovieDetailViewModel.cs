using System.Threading.Tasks;
using TopMovies.Base.ViewModels;
using TopMovies.Models;
using TopMovies.Services.Connection;
using TopMovies.Services.Details;
using TopMovies.Services.Dialog;
using TopMovies.Services.Navigation;
using Xamarin.Forms;

namespace TopMovies.ViewModels
{
    public class MovieDetailViewModel : ViewModelBase
    {
        #region Attributes
        private Movies.Result _selectedMovie;
        private readonly INavigationService _navigationService;
        private readonly IDetailMovie _detailMovie;
        readonly IConnectionService _connectionService;
        private MovieDetails _movieDetail;
        public string _title;
        public string _genreMain;
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
        public string GenreMain
        {
            get { return _genreMain; }
            set
            {
                _genreMain = value;
                OnPropertyChanged();
            }
        }
        public Movies.Result SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                OnPropertyChanged();
            }
        }

        public MovieDetails MovieDetail
        {
            get { return _movieDetail; }
            set
            {
                _movieDetail = value;
                OnPropertyChanged();
            }
        }
        #endregion


        #region Constructor
        public MovieDetailViewModel(IConnectionService connectionService, INavigationService navigationService, IDialogService dialogService, IDetailMovie detailMovie)
         : base(connectionService, navigationService, dialogService)
        {
            _detailMovie = detailMovie;
            _navigationService = navigationService;
            _connectionService = connectionService;
        }
        #endregion

        #region Methods
        public override async Task InitializeAsync(object data)
        {
            if (data != null)
            {
                //SelectedMovie = (Movies.Result)data;//data from home view
                //web service Detail by id
                var movieSelected = (Movies.Result)data;

                var connection = await this._connectionService.CheckConnection();

                if (!connection.IsSuccess)
                {
                    await Application.Current.MainPage.DisplayAlert("Network", connection.Message, "OK");
                    return;
                }

                MovieDetail = await _detailMovie.GetAllMovieDetailAsync(movieSelected.Id);
                var genre = MovieDetail.Genres;
                GenreMain = genre[0].Name + "  -  " + genre[1].Name + "  -  " + genre[2].Name;
            }

        }
        #endregion
    }
}
