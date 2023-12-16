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
using Microsoft.Maui.Controls;

namespace P04WeatherForecastAPI.Client
{
    class AppCurrentResources
    {

        public static string Token = "";
        public static string Language = "english";
        public static bool DarkTheme = false;

        public static void LoadSettings()
        {
            Token = Preferences.Get("token", "");
            Language = Preferences.Get("language", "english");
            SetTheme(Preferences.Get("isDarkTheme", false), false);
        }

        public static void SetToken(string token)
        {
            AppCurrentResources.Token = token;

            Preferences.Set("token", token);
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
                Preferences.Set("isDarkTheme", DarkTheme);
            }
        }

        public static void UpdateResources()
        {
            if (DarkTheme)
            {
                Application.Current.UserAppTheme = AppTheme.Dark;
            }
            else
            {
                Application.Current.UserAppTheme = AppTheme.Light;
            }
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

            Preferences.Set("language", language);
        }

    }
}
