using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P04Library.Client.Models;
using P06Library.Shared.MessageBox;
using P06Library.Shared.Services.LibraryService;
using P06Library.Shared.Library;
using P12MAUI.Client;
using P12MAUI.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Reflection;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using P06Library.Shared.Languages;
using System.Diagnostics;
using P06Library.Shared.Services.AuthService;
using Location = Microsoft.Maui.Devices.Sensors.Location;

namespace P12MAUI.Client.ViewModels
{
   
 public partial class MainViewModel : ObservableObject
    {
        private readonly int PageSize = 10;

        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageDialogService _messageDialogService;
        private readonly ITranslationsManager _translationsManager;
        private readonly ILibraryService _libraryService;
        private readonly IAuthService _authService;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly BookDetailsView _bookDetailsView;
        private readonly IConnectivity _connectivity;

        private readonly IGeolocation _geolocation;
        private readonly IMap _map;

        public AuthenticationState AuthenticationState;

        private string searchText = "";
        private int currentPage = 1;
        private int maxPage = 1;
        private string currentGPSMessageText = "";
        private bool currentIsLoadingBooks = false;
        public ObservableCollection<Book> Books { get; set; }

        [ObservableProperty]
        public string currentSearchText;

        private bool temporarilyAllowNextPreviousButton = false;

        public MainViewModel(IServiceProvider serviceProvider, ILibraryService libraryService, IAuthService authService,
            IMessageDialogService messageDialogService,
            ITranslationsManager translationsManager,
            AuthenticationStateProvider authenticationStateProvider,
            BookDetailsView bookDetailsView, IConnectivity connectivity, IGeolocation geolocation, IMap map)
        {
            _serviceProvider = serviceProvider;
            _messageDialogService = messageDialogService;
            _bookDetailsView = bookDetailsView;
            _libraryService = libraryService;
            _authService = authService;
            _translationsManager = translationsManager;
            _authenticationStateProvider = authenticationStateProvider;
            _connectivity = connectivity; // set the _connectivity field
            _geolocation = geolocation;
            _map = map;

            Books = new ObservableCollection<Book>();
            AppCurrentResources.LoadSettings();
            GetAuthenticationState();
            
            currentGPSMessageText = _translationsManager.Get(AppCurrentResources.Language, "LoadingGPSData");

            StartGpsService();
        }

        public async Task GetBooks()
        {
            GetBooks(searchText, currentPage);
        }

        [Obsolete]
        public async Task GetBooks(string searchText, int page)
        {
            Debug.WriteLine(">>> GetBooks...");

            currentIsLoadingBooks = true;
            OnPropertyChanged(nameof(IsLoadingBooks));

            Books.Clear();
            OnPropertyChanged(nameof(Books));

            this.searchText = searchText;
            var maxElementsResponse = await _libraryService.GetBooksCountAsync(searchText);
            int maxElements = maxElementsResponse != null ? maxElementsResponse.Data : 0;

            currentPage = page;
            maxPage = _libraryService.GetMaxPage(PageSize, maxElements);

            if (currentPage > maxPage)
            {
                currentPage = maxPage;
            }

            var booksResult = await _libraryService.SearchBooksAsync(searchText, currentPage, PageSize);

            if (booksResult != null && booksResult.Success)
            {
                foreach (var p in booksResult.Data)
                {
                    Books.Add(p);
                }
                Debug.WriteLine(">>> GetBooks SUCCEDED, added " + Books.Count + " books");
            }
            else
            {
                Debug.WriteLine(">>> GetBooks FAILED");
            }

            currentIsLoadingBooks = false;
            OnPropertyChanged(nameof(IsLoadingBooks));

            RefreshAllProperties();
            OnPropertyChanged(nameof(Books));
            OnPropertyChanged(nameof(IsBookListVisible));
            OnPropertyChanged(nameof(IsLoadingSpinnerVisible));
            OnPropertyChanged(nameof(CurrentPageText));
            OnPropertyChanged(nameof(IsNextButtonEnabled));
            OnPropertyChanged(nameof(IsPreviousButtonEnabled));

            temporarilyAllowNextPreviousButton = true;
            OnPropertyChanged(nameof(IsPreviousButtonEnabled));
            OnPropertyChanged(nameof(IsNextButtonEnabled));
            temporarilyAllowNextPreviousButton = false;
            OnPropertyChanged(nameof(IsPreviousButtonEnabled));
            OnPropertyChanged(nameof(IsNextButtonEnabled));
        }

        
        [RelayCommand]
        public async Task ShowDetails(Book book)
        {
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                _messageDialogService.ShowMessage("Internet not available!");
                return;
            }

            await Shell.Current.GoToAsync(nameof(BookDetailsView), true, new Dictionary<string, object>
            {
                {"Book", book },
                {nameof(MainViewModel), this }
            });
        }
        

        [RelayCommand]
        public async void OpenLoginWindow()
        {
            LoginView loginView = _serviceProvider.GetService<LoginView>();
            LoginViewModel loginViewModel = _serviceProvider.GetService<LoginViewModel>();

            loginViewModel.SetIsLogin(true);

            await Shell.Current.GoToAsync(nameof(LoginView), true, new Dictionary<string, object>
            {
                {nameof(MainViewModel), this }
            });
            //await Shell.Current.GoToAsync("//login", true);
        }

        [RelayCommand]
        public async void OpenRegisterWindow()
        {
            LoginView loginView = _serviceProvider.GetService<LoginView>();
            LoginViewModel loginViewModel = _serviceProvider.GetService<LoginViewModel>();

            loginViewModel.SetIsLogin(false);

            await Shell.Current.GoToAsync(nameof(LoginView), true, new Dictionary<string, object>
            {
                {nameof(MainViewModel), this }
            });
        }

        public async void GetAuthenticationState()
        {
            Debug.WriteLine("GetAuthenticationState ---------------------------------");
            AuthenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            _libraryService.SetAuthToken(AppCurrentResources.Token);
            _authService.SetAuthToken(AppCurrentResources.Token);
            GetBooks();
            RefreshAllProperties();
        }

        [RelayCommand]
        public async void Logout()
        {
            AppCurrentResources.SetToken("");
            GetAuthenticationState();
        }

        [RelayCommand]
        public void SwitchTheme()
        {
            AppCurrentResources.ToggleTheme();
            RefreshAllProperties();
        }

        [RelayCommand]
        public void SwitchLanguage()
        {
            AppCurrentResources.ToggleLanguage();
            RefreshAllProperties();

            CheckGpsLocation();
        }

        public void RefreshAllProperties()
        {
            OnPropertyChanged();
            var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                OnPropertyChanged(property.Name);
            }
        }

        [RelayCommand]
        public async void Search()
        {
            currentPage = 1;
            await GetBooks(CurrentSearchText, currentPage);
        }

        [RelayCommand]
        public void PreviousPage()
        {
            if (currentIsLoadingBooks || currentPage <= 1)
            {
                return;
            }
            currentPage--;
            GetBooks(searchText, currentPage);
            OnPropertyChanged(nameof(CurrentPageText));
            OnPropertyChanged(nameof(IsNextButtonEnabled));
            OnPropertyChanged(nameof(IsPreviousButtonEnabled));
        }

        [RelayCommand]
        public void NextPage()
        {
            if (currentIsLoadingBooks)
            {
                return;
            }
            currentPage++;
            GetBooks(searchText, currentPage);
            OnPropertyChanged(nameof(CurrentPageText));
            OnPropertyChanged(nameof(IsNextButtonEnabled));
            OnPropertyChanged(nameof(IsPreviousButtonEnabled));
        }

        [RelayCommand]
        public async void CreateBook()
        {
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                _messageDialogService.ShowMessage("Internet not available!");
                return;
            }

            Book SelectedBook = new Book();
            await Shell.Current.GoToAsync(nameof(BookDetailsView), true, new Dictionary<string, object>
            {
                {"Book", SelectedBook },
                {nameof(MainViewModel), this }
            });

            //BookFormView bookFormView = _serviceProvider.GetService<BookFormView>();
            //BookFormViewModel bookFormViewModel = _serviceProvider.GetService<BookFormViewModel>();

            //bookFormViewModel.SetEditingBook(-1);
            //bookFormView.Show();
        }

        [RelayCommand]
        public void EditBook(string id)
        {
            //BookFormView bookFormView = _serviceProvider.GetService<BookFormView>();
            //BookFormViewModel bookFormViewModel = _serviceProvider.GetService<BookFormViewModel>();

            //bookFormViewModel.SetEditingBook(int.Parse(id));
            //bookFormView.Show();
        }

        private Location currentLocation;
        private Location targetLocation;

        [Obsolete]
        private void StartGpsService()
        {
            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                CheckGpsLocation();
                return true;
            });
        }

        private async void CheckGpsLocation()
        {
            string _currentGPSMessageText = currentGPSMessageText;

            try
            {
                var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                {
                    currentGPSMessageText = _translationsManager.Get(AppCurrentResources.Language, "NoGPSPermission");
                    return;
                }

                //targetLocation = new Location(37.7749, -122.4194 + new Random().Next(1, 101)); // San Francisco

                targetLocation = new Location(52.22074189866894, 21.009735798216674); // Biblioteka Główna PW

                currentLocation = await _geolocation.GetLastKnownLocationAsync();

                double distanceInKilometers = Location.CalculateDistance(currentLocation, targetLocation, DistanceUnits.Kilometers);
                distanceInKilometers = Math.Round(distanceInKilometers, 3);

                currentGPSMessageText = _translationsManager.Get(AppCurrentResources.Language, "CurrentGPSDistance") + distanceInKilometers + " km";
            }
            catch (Exception ex)
            {
                currentGPSMessageText = _translationsManager.Get(AppCurrentResources.Language, "GPSServiceError") + ex.Message;
            }

            if (!string.Equals(currentGPSMessageText, _currentGPSMessageText))
            {
                OnPropertyChanged(nameof(GPSMessageText));
            }

            //Console.WriteLine("> " + currentGPSMessageText);
        }


        public string LibraryText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "Library"); }
        }

        public string LoggedUserText
        {
            get
            {
                string msg = AuthenticationState?.User?.Identity?.Name + " | " +
                       _translationsManager.Get(AppCurrentResources.Language, AuthenticationState?.User?.Claims?
                       .Where(c => c.Type == ClaimTypes.Role).FirstOrDefault()?.Value) + " ";

                string dateCreated = AuthenticationState?.User?.Claims?.Where(c => c.Type == "DateCreated")?.FirstOrDefault()?.Value;

                if (DateTime.TryParse(dateCreated, out DateTime parsedDate))
                {
                    string formattedDate = parsedDate.ToString("yyyy-MM-dd HH:mm:ss");
                    return (AuthenticationState == null ? "" : msg + formattedDate);
                }

                return (AuthenticationState == null ? "" : msg + AuthenticationState?.User?.Claims?.Where(c => c.Type == "DateCreated")?.FirstOrDefault()?.Value);
            }
        }

        public bool IsLoggedUserInvisible
        {
            get { return AppCurrentResources.Token == ""; }
        }

        public bool IsLoginButtonInvisible
        {
            get { return AppCurrentResources.Token != ""; }
        }

        public string CreateBookText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "CreateBook"); }
        }

        public string LoginText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "Login"); }
        }

        public string RegisterText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "Register"); }
        }

        public string LogoutText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "Logout"); }
        }

        public bool IsDarkTheme
        {
            get { return AppCurrentResources.DarkTheme; }
        }

        public bool IsLightTheme
        {
            get { return !AppCurrentResources.DarkTheme; }
        }

        public bool IsPolishLanguageInvinible
        {
            get { return AppCurrentResources.Language != "polish"; }
        }

        public bool IsEnglishLanguageInvinible
        {
            get { return AppCurrentResources.Language != "english"; }
        }

        public string SearchText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "Search"); }
        }

        public string PreviousText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "Previous"); }
        }

        public string NextText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "Next"); }
        }

        public string CurrentPageText
        {
            get { return currentPage + " / " + maxPage; }
        }

        public bool IsNextButtonEnabled
        {
            get { return currentPage < maxPage || temporarilyAllowNextPreviousButton; }
        }

        public bool IsPreviousButtonEnabled
        {
            get { return currentPage > 1 || temporarilyAllowNextPreviousButton; }
        }

        public bool IsPaginationVisible
        {
            get { return true; }
        }

        public bool IsBookListVisible
        {
            get { return Books?.Count > 0; }
        }

        public bool IsLoadingSpinnerVisible
        {
            get { return Books?.Count == 0 && searchText == ""; }
        }

        public bool IsLoadingBooks
        {
            get { return currentIsLoadingBooks && !IsLoadingSpinnerVisible; }
        }

        public string GPSMessageText
        {
            get { return currentGPSMessageText; }
        }

    }
}
