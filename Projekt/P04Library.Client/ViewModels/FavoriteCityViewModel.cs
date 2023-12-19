using CommunityToolkit.Mvvm.ComponentModel;
using P04Library.Client.Models;
using P04Library.Client.Services.WeatherServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04Library.Client.ViewModels
{
    public partial class FavoriteCityViewModel : ObservableObject
    {
        private readonly IFavoriteCityService _favoriteCityService;

        private ObservableCollection<FavoriteCity> _favoriteCity;

        [ObservableProperty]
        private FavoriteCity selectedCity;


        public FavoriteCityViewModel(IFavoriteCityService favoriteCityService)
        {
            _favoriteCityService = favoriteCityService;
        }


    }
}
