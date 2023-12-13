using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace P04WeatherForecastAPI.Client
{
    class AppCurrentResources
    {

        public static bool DarkTheme = false;


        public static void ToggleTheme()
        {
            SetTheme(!DarkTheme);
        }

        public static void SetTheme(bool DarkTheme)
        {
            AppCurrentResources.DarkTheme = DarkTheme;
            UpdateResources();
        }

        public static void UpdateResources()
        {
            Uri themeUri = new Uri("Themes/" + (DarkTheme ? "Dark" : "Light") + "Theme.xaml", UriKind.Relative);
            //Uri languageUri = new Uri("Resources/" + Enum.GetName(CurrentLanguage) + ".xaml");

            App.Current.Resources.Clear();
            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = themeUri });
            //App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = languageUri });
        }
    }
}
