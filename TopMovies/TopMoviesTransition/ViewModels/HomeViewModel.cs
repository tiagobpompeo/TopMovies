using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TopMoviesTransition.Base.ViewModels;
using TopMoviesTransition.Helpers;
using TopMoviesTransition.Models;
using TopMoviesTransition.Services.Connection;
using TopMoviesTransition.Services.Details;
using TopMoviesTransition.Services.Dialog;
using TopMoviesTransition.Services.Navigation;
using TopMoviesTransition.Services.Settings;
using TopMoviesTransition.Services.UpComing;


namespace TopMoviesTransition.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        #region Attributes
        private readonly IUpComing _upComingService;
        public readonly ISettingsService _settingsService;
        private IConnectionService _connectionService;//keep
        public int pageIndex = 0;
        public bool _isWorking;
        public string _searchText;
        public string _title;
        private ObservableCollection<Movies.Result> _ItemsUnfiltered;
        public List<Movies.Result> Movies { get; set; }
        public string _genreMain;
        public string genreOut;
        public string connectionMessage;
        private readonly IDetailMovie _detailMovie;
        public bool isrefreshing;
        #endregion

        #region Properties
        public bool IsRefreshing
        {
            get { return this.isrefreshing; }
            set { SetValue(ref this.isrefreshing, value); }
        }

        public string ConnectionMessage
        {
            get { return connectionMessage; }
            set
            {
                connectionMessage = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        public bool IsWorking
        {
            get => _isWorking;
            set
            {
                _isWorking = value;
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
        #endregion

        #region Command
        public ICommand MovieTappedCommand => new Command<Movies.Result>(OnMovieTapped);
        public ICommand SearchCommand => new Command<string>(SearchMovie);
        public ICommand TextChangeInSearchCommand { get; private set; }
        #endregion

        #region Constructor
        public HomeViewModel(IConnectionService connectionService, INavigationService navigationService,
            IDialogService dialogService, IUpComing upComingService, IDetailMovie detailMovie)
        : base(connectionService, navigationService, dialogService)
        {
            _upComingService = upComingService;
            _detailMovie = detailMovie;
            _connectionService = connectionService;
            Title = "Upcoming";
            TextChangeInSearchCommand = new Command(PerformSearch);

            Movies = new InfiniteScrollCollection<Movies.Result>
            {
                //scroll user action trigger this event
                OnLoadMore = async () =>
                {
                    var connection = await this._connectionService.CheckConnection();
                    if (!connection.IsSuccess)
                    {
                        ConnectionMessage = connection.Message;
                        return null;
                    }
                    else
                    {
                        IsWorking = true;
                        pageIndex++;
                        var movies = await _upComingService.GetAllMoviesAsync(pageIndex);
                        var count = movies.Count;
                        _ItemsUnfiltered = new InfiniteScrollCollection<Movies.Result>(movies);
                        IsWorking = false;
                        return movies;
                    }
                }
            };


            Movies.LoadMoreAsync();

        }
        #endregion

        #region Methods
        private async void CheckConnection()
        {
            var connection = await this._connectionService.CheckConnection();

            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Conexão de Rede", connection.Message, "OK");
                return;
            }
        }

        private void OnMovieTapped(Movies.Result selectedMovie)
        {
            _navigationService.NavigateToAsync<MovieDetailViewModel>(selectedMovie);
        }

        public void PerformSearch()
        {
            if (string.IsNullOrWhiteSpace(this._searchText))
            {
            }
            else
            {
                Movies = new InfiniteScrollCollection<Movies.Result>(_ItemsUnfiltered.Where(i => (i is Movies.Result && (((Movies.Result)i)
                 .Title.ToLower()
                 .Contains(_searchText.ToLower())))));
            }
        }

        private void SearchMovie(string movieText)
        {
            Movies = new InfiniteScrollCollection<Movies.Result>(_ItemsUnfiltered.Where(i => (i is Movies.Result && (((Movies.Result)i)
                .Title.ToLower()
                .Contains(movieText.ToLower())))));
        }

        public override Task InitializeAsync(object data)
        {
            return base.InitializeAsync(data);
        }

        #endregion
    }
}
