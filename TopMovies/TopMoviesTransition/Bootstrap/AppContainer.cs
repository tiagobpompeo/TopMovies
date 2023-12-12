using System;
using Autofac;
using TopMoviesTransition.Repository;
using TopMoviesTransition.Services.Authentication;
using TopMoviesTransition.Services.Connection;
using TopMoviesTransition.Services.Details;
using TopMoviesTransition.Services.Dialog;
using TopMoviesTransition.Services.Navigation;
using TopMoviesTransition.Services.Settings;
using TopMoviesTransition.Services.UpComing;
using TopMovies.ViewModels;

namespace TopMoviesTransition.Bootstrap
{
    public static class AppContainer
    {
        private static Autofac.IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //ViewModels
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<HomeViewModel>();
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<MenuViewModel>();
            builder.RegisterType<RegistrationViewModel>();
            builder.RegisterType<MovieDetailViewModel>();
            builder.RegisterType<NewPageViewModel>();

            //services - data
            builder.RegisterType<UpComingService>().As<IUpComing>();
            builder.RegisterType<MovieDetailService>().As<IDetailMovie>();

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

        //Resolve : casos em que eh necessario instancia, e nao ha injecao de dependencia no construtor(casos VM)
        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}