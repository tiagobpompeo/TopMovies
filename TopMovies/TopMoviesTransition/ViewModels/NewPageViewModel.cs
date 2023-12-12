using System;
using TopMoviesTransition.Base.ViewModels;
using TopMoviesTransition.Services.Connection;
using TopMoviesTransition.Services.Dialog;
using TopMoviesTransition.Services.Navigation;

namespace TopMoviesTransition.ViewModels
{
    public class NewPageViewModel : ViewModelBase
    {
        public NewPageViewModel(IConnectionService connectionService, INavigationService navigationService, IDialogService dialogService) 
            : base(connectionService, navigationService, dialogService)
        {
        }
    }
}
