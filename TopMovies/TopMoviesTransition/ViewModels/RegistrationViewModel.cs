using System;
using TopMoviesTransition.Base.ViewModels;
using TopMoviesTransition.Services.Connection;
using TopMoviesTransition.Services.Dialog;
using TopMoviesTransition.Services.Navigation;

namespace TopMovies.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        public RegistrationViewModel(IConnectionService connectionService, INavigationService navigationService, IDialogService dialogService) : base(connectionService, navigationService, dialogService)
        {
        }
    }
}
