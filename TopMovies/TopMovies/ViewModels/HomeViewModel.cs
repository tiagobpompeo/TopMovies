using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TopMovies.Base.ViewModels;
using TopMovies.Models;
using TopMovies.Services.Connection;
using TopMovies.Services.Details;
using TopMovies.Services.Dialog;
using TopMovies.Services.Navigation;
using TopMovies.Services.Settings;
using TopMovies.Services.UpComing;
using Xamarin.Forms;
using Xamarin.Forms.Extended;

namespace TopMovies.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        #region Attributes
        private readonly IUpComing _upComingService;
        private InfiniteScrollCollection<Movies.Result> _ItemsFiltered;
        public readonly ISettingsService _settingsService;
        private IConnectionService _connectionService;
        public int pageIndex = 0;
        public bool _isWorking;
        public string _searchText;
        public string _title;
        public ICommand RefreshCommand { get; }
        private ObservableCollection<Movies.Result> _ItemsUnfiltered;
        public InfiniteScrollCollection<Movies.Result> Movies { get; }
        public string _genreMain;
        public string genreOut;
        public string connectionMessage;
        private readonly IDetailMovie _detailMovie;
        #endregion

        #region Properties
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
        public ICommand SearchCommand { get; private set; }
        #endregion

        #region Constructor
        public HomeViewModel(IConnectionService connectionService, INavigationService navigationService,
            IDialogService dialogService, IUpComing upComingService, IDetailMovie detailMovie)
        : base(connectionService, navigationService, dialogService)
        {
            _upComingService = upComingService;
            _detailMovie = detailMovie;
            _connectionService = connectionService;
            SearchCommand = new Command(PerformSearch);
            Title = "Upcoming";

            Movies = new InfiniteScrollCollection<Movies.Result>
            {
                //scroll dispara esse evento
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
                        _ItemsUnfiltered = new ObservableCollection<Movies.Result>(movies);
                        IsWorking = false;
                        return movies;
                    }
                }
            };

            Movies.LoadMoreAsync();
        }

        private async void CheckConnection()
        {
            var connection = await this._connectionService.CheckConnection();

            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Conexão de Rede", connection.Message, "OK");
                return;
            }
        }

        #endregion

        #region Methods
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
                _ItemsFiltered = new InfiniteScrollCollection<Movies.Result>(_ItemsUnfiltered.Where(i => (i is Movies.Result && (((Movies.Result)i)
                                                 .Title.ToLower()
                                                 .Contains(_searchText.ToLower())))));
            }
        }

        public override async Task InitializeAsync(object data)
        {

        }
        #endregion
    }
}
