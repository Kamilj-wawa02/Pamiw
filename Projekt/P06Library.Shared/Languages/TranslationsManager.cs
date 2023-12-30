using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06Library.Shared.Languages
{
    public class TranslationsManager : ITranslationsManager
    {
        public Dictionary<string, Dictionary<string, string>> loadedLanguages = new Dictionary<string, Dictionary<string, string>>();

        public TranslationsManager()
        {
            LoadLanguages();
        }

        /*
        public Dictionary<string, IConfiguration> loadedLanguages = new Dictionary<string, IConfiguration>();

        public TranslationsManager(string projectDir)
        {
            LoadLanguages(projectDir);
        }

        
        public void LoadLanguages(string translationsDir)
        {
            string[] languages = new string[] { "polish", "english" };

            string basePath = translationsDir;
                        
            for (int i = 0; i < languages.Length; i++)
            {
                string language = languages[i];
                var builder = new ConfigurationBuilder()
                  .SetBasePath(basePath)
                  .AddJsonFile(language + ".json");
                IConfiguration _configuration = builder.Build();
                loadedLanguages.Add(language, _configuration);
            }
        }

        public string Get(string language, string key)
        {
            loadedLanguages.TryGetValue(language, out IConfiguration value);
            return value?.GetSection("Translations:" + key)?.Value;
        }
        */


        public void LoadLanguages()
        {
            loadedLanguages = new Dictionary<string, Dictionary<string, string>>
            {
                { "english", new Dictionary<string, string>
                    {
                        { "Library", "Library" },
                        { "WelcomeTitle", "Welcome to the silence zone!" },
                        { "WelcomeSubtitle", "Feel free to browse through the library!" },
                        { "Customer", "Customer" },
                        { "LoginForm", "Login" },
                        { "Login", "Login" },
                        { "Log_in", "Login in" },
                        { "Logout", "Logout" },
                        { "LoginWithFacebook", "Login with Facebook" },
                        { "RegisterForm", "Register" },
                        { "Register", "Register" },
                        { "Email", "Email" },
                        { "Username", "Username" },
                        { "Password", "Password" },
                        { "ConfirmPassword", "Confirm password" },
                        { "About", "About" },
                        { "OpenBookList", "Open books list" },
                        { "Home", "Main page" },
                        { "BookListTitle", "List of books" },
                        { "CreateBook", "Create new book" },
                        { "Search", "Search" },
                        { "Previous", "Previous" },
                        { "Next", "Next" },
                        { "Title", "Title" },
                        { "Author", "Author" },
                        { "Barcode", "Barcode" },
                        { "Price", "Price" },
                        { "ReleaseDate", "Release date" },
                        { "Description", "Description" },
                        { "Save", "Save" },
                        { "Delete", "Delete" },
                        { "WrongLoginDataMessage", "Provided data don't meet the requirements! Check if the passord has min 6 characters and if the email is in correct format!" },
                        { "EmptyData", "Please fill in all fields!" },
                        { "NotTheSamePasswords", "The passwords you entered are not the same!" },
                        { "UserNotFound", "User not found!" },
                        { "UserNotLoggedInTitle", "Whoops! You're not allowed to see this page." },
                        { "UserNotLoggedInSubtitle", "Please login or register a new account." },
                        { "FailedCreatingBook", "Failed to create a new book! Error details: " },
                        { "FailedUpdatingBook", "Failed to update the book! Error details: " },
                        { "FailedDeletingBook", "Failed to delete the book! Error details: " },
                        { "LoginFailed", "Login failed! Message: " },
                        { "RegistrationFailed", "Registration failed! Message: " },
                        { "RegisteredSuccessfully", "Registered successfully! Now log in to your account." },
                        { "NoGPSPermission", "No permission to access the GPS data!" },
                        { "GPSServiceError", "Error while turning on GPS service! Message: " },
                        { "LoadingGPSData", "Loading GPS data..." },
                        { "CurrentGPSDistance", "Current distance to the library: " },
                        { "YouMustBeLoggedInToSeeBooks", "You must be logged in to see the list of books!" },
                        { "RequestFailed", "The request has failed! Try logging in again. Error details: " },
                    }
                },
                { "polish", new Dictionary<string, string>
                    {
                        { "Library", "Biblioteka" },
                        { "WelcomeTitle", "Witaj w strefie ciszy!" },
                        { "WelcomeSubtitle", "Śmiało, poprzeglądaj nasze książki!" },
                        { "Customer", "Klient" },
                        { "LoginForm", "Logowanie" },
                        { "Log_in", "Zaloguj" },
                        { "Login", "Zaloguj" },
                        { "Logout", "Wyloguj" },
                        { "LoginWithFacebook", "Zaloguj przez Facebook" },
                        { "RegisterForm", "Rejestracja" },
                        { "Register", "Zarejestruj" },
                        { "Email", "Email" },
                        { "Username", "Nazwa użytkownika" },
                        { "Password", "Hasło" },
                        { "ConfirmPassword", "Powtórz hasło" },
                        { "About", "Informacje" },
                        { "OpenBookList", "Otwórz listę książek" },
                        { "Home", "Strona główna" },
                        { "BookListTitle", "Lista książek" },
                        { "CreateBook", "Dodaj nową książkę" },
                        { "Search", "Szukaj" },
                        { "Previous", "Poprzednia" },
                        { "Next", "Następna" },
                        { "Title", "Tytuł" },
                        { "Author", "Autor" },
                        { "Barcode", "Barkod" },
                        { "Price", "Cena" },
                        { "ReleaseDate", "Data wydania" },
                        { "Description", "Opis" },
                        { "Save", "Zapisz" },
                        { "Delete", "Usuń" },
                        { "WrongLoginDataMessage", "Wprowadzone dane nie spełniają wymagań! Sprawdź, czy hasło ma minimalnie 6 znaków i czy email ma prawidłowy format!" },
                        { "EmptyData", "Wypełnij wszystkie pola!" },
                        { "NotTheSamePasswords", "Wprowadzone hasła nie są takie same!" },
                        { "UserNotFound", "Nie odnaleziono użytkownika!" },
                        { "UserNotLoggedInTitle", "Ups! Nie masz uprawnień do przeglądania tej strony." },
                        { "UserNotLoggedInSubtitle", "Proszę zaloguj się lub zarejestruj nowe konto." },
                        { "FailedCreatingBook", "Nie udało się utworzyć książki! Komunikat błędu: " },
                        { "FailedUpdatingBook", "Nie udało się zaktualizować książki! Komunikat błędu: " },
                        { "FailedDeletingBook", "Nie udało się usunąć książki! Komunikat błędu: " },
                        { "LoginFailed", "Nie udało się zalogować! Treść komunikatu: " },
                        { "RegistrationFailed", "Nie udało się zarejestrować! Treść komunikatu: " },
                        { "RegisteredSuccessfully", "Zarejestrowano pomyślnie! Teraz zaloguj się na swoje konto." },
                        { "NoGPSPermission", "Brak uprawnień do używania danych GPS!" },
                        { "GPSServiceError", "Wystąpił błąd przy uruchamianiu serwisu GPS! Komunikat: " },
                        { "LoadingGPSData", "Ładuję dane GPS..." },
                        { "CurrentGPSDistance", "Aktualny dystans do biblioteki: " },
                        { "YouMustBeLoggedInToSeeBooks", "Musisz być zalogowany, aby móc wyświetlić listę książek!" },
                        { "RequestFailed", "Żądanie się nie powiodło! Spróbuj ponownie się zalogować. Komunikat błędu: " },
                    }
                }
            };
        }

        public string Get(string language, string key)
        {
            if (language == null) { language = "english";}

            if (key == null) { return null;  }

            if (loadedLanguages.TryGetValue(language, out var languageTranslations))
            {
                if (languageTranslations.TryGetValue(key, out var translation))
                {
                    return translation;
                }
            }

            return key;
        }
    }
}