using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using TopMovies.UITests.ViewModel;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TopMovies.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void WelcomeTextIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            app.Screenshot("Welcome screen.");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public async void Movies_Not_Null_Test()
        {
            var vm = new HomeViewModelTest();
            await vm.Movies_Not_Null_Test();
        }
    }
}
