using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TopMoviesTransition.Base.ViewModels;
using TopMoviesTransition.Enumerations;
using TopMoviesTransition.Models;
using TopMoviesTransition.Services.Connection;
using TopMoviesTransition.Services.Dialog;
using TopMoviesTransition.Services.Navigation;
using TopMoviesTransition.Services.Settings;


namespace TopMoviesTransition.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private ObservableCollection<MainMenuItem> _menuItems;
        private readonly ISettingsService _settingsService;

        public MenuViewModel(IConnectionService connectionService,
            INavigationService navigationService, IDialogService dialogService,
            ISettingsService settingsService)
            : base(connectionService, navigationService, dialogService)
        {
            _settingsService = settingsService;
            MenuItems = new ObservableCollection<MainMenuItem>();
            LoadMenuItems();
        }

        public string WelcomeText => "Hello " + _settingsService.UserNameSetting;

        public ICommand MenuItemTappedCommand => new Command(OnMenuItemTapped);

        public ObservableCollection<MainMenuItem> MenuItems
        {
            get => _menuItems;
            set
            {
                _menuItems = value;
                OnPropertyChanged();
            }
        }

        private void OnMenuItemTapped(object menuItemTappedEventArgs)
        {
            var menuItem = ((menuItemTappedEventArgs as ItemTappedEventArgs)?.Item as MainMenuItem);

            if (menuItem != null && menuItem.MenuText == "Log out")
            {
                _settingsService.UserIdSetting = null;
                _settingsService.UserNameSetting = null;
                _navigationService.ClearBackStack();
            }

            var type = menuItem?.ViewModelToLoad;
            _navigationService.NavigateToAsync(type);
        }

        private void LoadMenuItems()
        {
            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Upcoming",
                ViewModelToLoad = typeof(MainViewModel),
                MenuItemType = MenuItemType.MainPage
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "New Page",
                ViewModelToLoad = typeof(NewPageViewModel),
                MenuItemType = MenuItemType.NewPage
            });


        }
    }
}