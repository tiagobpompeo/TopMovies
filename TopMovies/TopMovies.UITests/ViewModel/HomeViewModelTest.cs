using Moq;
using System.Threading.Tasks;
using TopMovies.Services.Connection;
using TopMovies.Services.Details;
using TopMovies.Services.Dialog;
using TopMovies.Services.Navigation;
using TopMovies.UITests.Mocks;
using TopMovies.ViewModels;
using Xunit;

namespace TopMovies.UITests.ViewModel
{
    public class HomeViewModelTest
    {
        [Fact]
        public async Task Movies_Not_Null_Test()
        {
            var mockConnectionService = new Mock<IConnectionService>();
            var mockNavigationService = new Mock<INavigationService>();
            var mockDialogService = new Mock<IDialogService>();
            var mockCatalogDataService = new MockUpComingService();
            var mockDetailComingService = new Mock<IDetailMovie>();

            var homeViewModel = new HomeViewModel(
                     mockConnectionService.Object,
                     mockNavigationService.Object,
                     mockDialogService.Object,
                     mockCatalogDataService,
                     mockDetailComingService.Object);
            await homeViewModel.InitializeAsync(null);
            Assert.NotNull(homeViewModel.Movies);
        }
    }

}
