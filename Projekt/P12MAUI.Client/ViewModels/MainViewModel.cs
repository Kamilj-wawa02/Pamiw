﻿using CommunityToolkit.Mvvm.ComponentModel;
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

        public AuthenticationState AuthenticationState;

        private string searchText = "";
        private int currentPage = 1;
        private int maxPage = 1;
        public ObservableCollection<Book> Books { get; set; }

        [ObservableProperty]
        public string currentSearchText;

        public MainViewModel(IServiceProvider serviceProvider, ILibraryService libraryService, IAuthService authService,
            IMessageDialogService messageDialogService,
            ITranslationsManager translationsManager,
            AuthenticationStateProvider authenticationStateProvider,
            BookDetailsView bookDetailsView, IConnectivity connectivity)
        {

            _serviceProvider = serviceProvider;
            _messageDialogService = messageDialogService;
            _bookDetailsView = bookDetailsView;
            _libraryService = libraryService;
            _authService = authService;
            _translationsManager = translationsManager;
            _authenticationStateProvider = authenticationStateProvider;
            _connectivity = connectivity; // set the _connectivity field

            AppCurrentResources.LoadSettings();
            GetAuthenticationState();
            Books = new ObservableCollection<Book>();
            GetBooks("", 1);
        }

        public async Task GetBooks()
        {
            GetBooks(searchText, currentPage);
        }

        public async Task GetBooks(string searchText, int page)
        {
            Debug.WriteLine(">>> GetBooks");

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
            Books.Clear();
            if (booksResult != null && booksResult.Success)
            {
                foreach (var p in booksResult.Data)
                {
                    Books.Add(p);
                }
                Debug.WriteLine(">>> GetBooks SUCCEDED");
            }
            else
            {
                Debug.WriteLine(">>> GetBooks FAILED");
            }

            RefreshAllProperties();
            OnPropertyChanged(nameof(Books));
            OnPropertyChanged(nameof(IsBookListVisible));
            OnPropertyChanged(nameof(IsLoadingSpinnerVisible));
            OnPropertyChanged(nameof(CurrentPageText));
            OnPropertyChanged(nameof(IsNextButtonEnabled));
            OnPropertyChanged(nameof(IsPreviousButtonEnabled));
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
            if (currentPage <= 1)
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
        

        public string LibraryText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "Library"); }
        }

        public string LoggedUserText
        {
            get
            {
                return (AuthenticationState == null ? "" :
                    AuthenticationState?.User?.Identity?.Name + " | " +
                    _translationsManager.Get(AppCurrentResources.Language, AuthenticationState?.User?.Claims?.Where(c => c.Type == ClaimTypes.Role).FirstOrDefault()?.Value) +
                    " " + AuthenticationState?.User?.Claims?.Where(c => c.Type == "DateCreated")?.FirstOrDefault()?.Value);
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
            get { return currentPage < maxPage; }
        }

        public bool IsPreviousButtonEnabled
        {
            get { return currentPage > 1; }
        }

        public bool IsPaginationVisible
        {
            get { return true; }
        }

        public bool IsBookListVisible
        {
            get { return Books.Count > 0; }
        }

        public bool IsLoadingSpinnerVisible
        {
            get { return Books.Count == 0 && searchText == ""; }
        }

    }
}