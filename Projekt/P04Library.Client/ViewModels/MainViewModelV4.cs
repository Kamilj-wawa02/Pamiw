﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using P04Library.Client.Commands;
using P04Library.Client.DataSeeders;
using P04Library.Client.Models;
using P04Library.Client.Services.WeatherServices;
using P06Library.Shared.Languages;
using P06Library.Shared.MessageBox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace P04Library.Client.ViewModels
{
    // przekazywanie wartosci do innego formularza 
    public partial class MainViewModelV4 : ObservableObject
    {
        private CityViewModel _selectedCity;
        private Weather _weather;
        private readonly IAccuWeatherService _accuWeatherService;

        //favorite city 
        private readonly FavoriteCitiesView _favoriteCitiesView;
        private readonly FavoriteCityViewModel _favoriteCityViewModel;
        //public ICommand LoadCitiesCommand { get;  }
        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageDialogService _messageDialogService;

        private readonly ITranslationsManager _translationsManager;

        [ObservableProperty]
        private string _language = "english";

        public MainViewModelV4(IAccuWeatherService accuWeatherService, 
            FavoriteCityViewModel favoriteCityViewModel, FavoriteCitiesView favoriteCitiesView,
            IServiceProvider serviceProvider, IMessageDialogService messageDialogService, ITranslationsManager translationsManager)
        {
            _favoriteCitiesView = favoriteCitiesView;
            _favoriteCityViewModel = favoriteCityViewModel;

            _serviceProvider = serviceProvider;

                // _serviceProvider= serviceProvider; 
                //LoadCitiesCommand = new RelayCommand(x => LoadCities(x as string));
                _accuWeatherService = accuWeatherService;
            Cities = new ObservableCollection<CityViewModel>(); // podejście nr 2 

            _messageDialogService = messageDialogService;

            _translationsManager = translationsManager;

        }

        //[ObservableProperty]
        //private WeatherViewModel weatherView;
        //public WeatherViewModel WeatherView { 
        //    get { return weatherView; } 
        //    set { 
        //        weatherView = value;
        //        OnPropertyChanged();
        //    }
        //}
        [ObservableProperty]
        private WeatherViewModel weatherView;


        public CityViewModel SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged();
                LoadWeather();
            }
        }

         
        private async void LoadWeather()
        {
            if(SelectedCity != null)
            {
                _weather = await _accuWeatherService.GetCurrentConditions(SelectedCity.Key); 
                WeatherView = new WeatherViewModel(_weather);
            }
        } 

        // podajście nr 2 do przechowywania kolekcji obiektów:
        public ObservableCollection<CityViewModel> Cities { get; set; }

        [RelayCommand]
        public async void LoadCities(string locationName)
        {
            // podejście nr 2:
            var cities = await _accuWeatherService.GetLocations(locationName);
            Cities.Clear();
            foreach (var city in cities) 
                Cities.Add(new CityViewModel(city));
        }

        [RelayCommand]
        public void OpenFavotireCities()
        {
            //var favoriteCitiesView = new FavoriteCitiesView();
            _favoriteCityViewModel.SelectedCity = new FavoriteCity() { Name = "Warsaw" };
            _favoriteCitiesView.Show();
        }

        [RelayCommand]
        public void OpenLibraryWindow()
        {
            //if (!string.IsNullOrEmpty(LoginViewModel.Token))
            //{
                LibraryBooksView libraryBooksView = _serviceProvider.GetService<LibraryBooksView>();
                BooksViewModel libraryBooksViewModel = _serviceProvider.GetService<BooksViewModel>();

                libraryBooksView.Show();
                libraryBooksViewModel.GetBooks();
            //}
            //else
            //{
            //    _messageDialogService.ShowMessage("Access denied! Log in first!");
            //}
        }

        [RelayCommand]
        public void OpenLoginWindow()
        {
            LoginView loginView = _serviceProvider.GetService<LoginView>();
            LoginViewModel loginViewModel = _serviceProvider.GetService<LoginViewModel>();

            loginView.Show();

        }
        
        [RelayCommand]
        public void SwitchTheme()
        {
            AppCurrentResources.ToggleTheme();
        }

        [RelayCommand]
        public void SwitchLanguage()
        {
            if (_language == "polish")
            {
                _language = "english";
            }
            else
            {
                _language = "polish";
            }

            OnPropertyChanged();
            var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                OnPropertyChanged(property.Name);
            }
        }

        public string OpenBookListText
        {
            get { return _translationsManager.Get(_language, "OpenBookList"); }
        }
    }
}