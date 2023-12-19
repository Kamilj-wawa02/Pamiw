using P04Library.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04Library.Client.Services.WeatherServices
{
    public interface IFavoriteCityService
    {
        public List<FavoriteCity> GetAllFavoriteCities();

        public void AddFavoriteCity(FavoriteCity city);
        public void RemoveFavoriteCity(int id);


    }
}
