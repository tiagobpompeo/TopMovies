using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Threading.Tasks;
using TopMovies.Bootstrap;
using TopMovies.Services.Navigation;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TopMovies
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitializeApp();
            InitializeNavigation();
        }

        private void InitializeApp()
        {
            Akavache.Registrations.Start("TopMovies");
            AppContainer.RegisterDependencies();
        }

        private async Task InitializeNavigation()
        {
            var navigationService = AppContainer.Resolve<INavigationService>();
            await navigationService.InitializeAsync();
        }


        protected override void OnStart()
        {
            Akavache.Registrations.Start("TopMovies");

            AppCenter.Start("android=d7d52d04-42e4-4ecc-85d7-fc8416e9bf10;"
             + "uwp={Your UWP App secret here};"
             + "ios=37016975-c842-442f-88f7-b84528e3ef1d;", typeof(Analytics), typeof(Crashes));
        }


        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
