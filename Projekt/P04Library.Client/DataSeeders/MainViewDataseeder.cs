using P04Library.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04Library.Client.DataSeeders
{
    internal class MainViewDataseeder
    {
        public static Weather GenerateWeather =>
            new Weather()
            {
                Temperature = new Temperature()
                {
                    Metric = new Metric()
                    {
                        Value = 20,
                    }
                }
            };

        public static City GenerateSelectedCity => new City() { LocalizedName = "Warszawa" };

        public static City[] GenerateCities => new City[]
        {
            new City() {  LocalizedName="Warszawa" },
            new City() {  LocalizedName="Paris" },
            new City() {  LocalizedName="Berlin" },
        };
    }
}
