﻿using System;
using Autofac;
using TopMovies.Repository;
using TopMovies.Services.Authentication;
using TopMovies.Services.Connection;
using TopMovies.Services.Details;
using TopMovies.Services.Dialog;
using TopMovies.Services.Navigation;
using TopMovies.Services.Settings;
using TopMovies.Services.UpComing;
using TopMovies.ViewModels;

namespace TopMovies.Bootstrap
{
    public static class AppContainer
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