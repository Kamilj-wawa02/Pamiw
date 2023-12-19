using P04Library.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04Library.Client.ViewModels
{
    public class CityViewModel
    {
        public string LocalizedName { get; set; }
        public string Key { get; set; }

        public CityViewModel(City city)
        {
            LocalizedName = city.LocalizedName; 
            Key = city.Key;
        }
    }
}
