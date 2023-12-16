using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
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

        public static string Token = "";
        public static string Language = "english";
        public static bool DarkTheme = false;

        public static void LoadSettings()
        {
            Token = Properties.Settings.Default.token;
            Language = Properties.Settings.Default.language;
            SetTheme(Properties.Settings.Default.isDarkTheme, false);
        }

        public static void SetToken(string token)
        {
            AppCurrentResources.Token = token;

            Properties.Settings.Default.token = token;
            Properties.Settings.Default.Save();
        }

        // THEME

        public static void ToggleTheme()
        {
            SetTheme(!DarkTheme, true);
        }

        public static void SetTheme(bool DarkTheme, bool save)
        {
            AppCurrentResources.DarkTheme = DarkTheme;
            UpdateResources();

            if (save)
            {
                Properties.Settings.Default.isDarkTheme = DarkTheme;
                Properties.Settings.Default.Save();
            }
        }

        public static void UpdateResources()
        {
            Uri themeUri = new Uri("Themes/" + (DarkTheme ? "Dark" : "Light") + "Theme.xaml", UriKind.Relative);
            //Uri languageUri = new Uri("Resources/" + Enum.GetName(CurrentLanguage) + ".xaml");

            App.Current.Resources.Clear();
            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = themeUri });
            //App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = languageUri });
        }

        // LANGUAGE

        public static void ToggleLanguage()
        {
            if (Language == "polish")
            {
                SetLanguage("english");
            }
            else
            {
                SetLanguage("polish");
            }
        }

        public static void SetLanguage(string language)
        {
            AppCurrentResources.Language = language;

            Properties.Settings.Default.language = language;
            Properties.Settings.Default.Save();
        }

    }
}
