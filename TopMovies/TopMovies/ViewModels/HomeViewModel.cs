using System;
using TopMovies.Base.ViewModels;
using TopMovies.Services.Connection;
using TopMovies.Services.Dialog;
using TopMovies.Services.Navigation;

namespace TopMovies.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel(IConnectionService connectionService, INavigationService navigationService, IDialogService dialogService) : base(connectionService, navigationService, dialogService)
        {
        }
    }
}
