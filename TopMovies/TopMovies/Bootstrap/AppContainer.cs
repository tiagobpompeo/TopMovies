using System;
using Autofac;
using TopMovies.Repository;
using TopMovies.Services.Authentication;
using TopMovies.Services.Connection;
using TopMovies.Services.Dialog;
using TopMovies.Services.Navigation;
using TopMovies.Services.Settings;
using TopMovies.ViewModels;

namespace TopMovies.Bootstrap
{
    public class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //ViewModels
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<HomeViewModel>();
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<MenuViewModel>();
            builder.RegisterType<RegistrationViewModel>();

            //services - data
            //builder.RegisterType<ClubesService>().As<IClubeService>();

            //services - general
            builder.RegisterType<ConnectionService>().As<IConnectionService>();

            //General
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<GenericRepository>().As<IGenericRepository>();
            builder.RegisterType<DialogServices>().As<IDialogService>();
            builder.RegisterType<SettingsService>().As<ISettingsService>().SingleInstance();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();

            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}