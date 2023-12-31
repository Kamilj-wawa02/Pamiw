using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using P04Library.Client.Commands;
using P06Library.Shared.Languages;
using P06Library.Shared.Library;
using P06Library.Shared.MessageBox;
using P06Library.Shared.Services.AuthService;
using P06Library.Shared.Services.LibraryService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace P04Library.Client.ViewModels
{
    // przekazywanie wartosci do innego formularza 
    public partial class LibraryMainViewModel : ObservableObject
    {
        private readonly int PageSize = 10;

        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageDialogService _messageDialogService;
        private readonly ITranslationsManager _translationsManager;
        private readonly ILibraryService _libraryService;
        private readonly IAuthService _authService;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationState AuthenticationState;

        private string searchText = "";
        private int currentPage = 1;
        private int maxPage = 1;

        private bool currentIsLoadingBooks = false;

        [ObservableProperty]
        private Book selectedBook;
        public ObservableCollection<Book> Books { get; set; }

        public LibraryMainViewModel(IServiceProvider serviceProvider, IMessageDialogService messageDialogService,
            ITranslationsManager translationsManager, ILibraryService libraryService, IAuthService authService,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _serviceProvider = serviceProvider;
            _messageDialogService = messageDialogService;
            _translationsManager = translationsManager;
            _libraryService = libraryService;
            _authService = authService;
            _authenticationStateProvider = authenticationStateProvider;

            Debug.WriteLine("============== Getting AuthState");
            
            Books = new ObservableCollection<Book>();
            GetAuthenticationState();
        }

        public async Task GetBooks()
        {
            GetBooks(this.searchText, this.currentPage);
        }

        public async Task GetBooks(string searchText, int page)
        {
            Debug.WriteLine(">>>>>>>>>>>>>>>> GetBooks");

            currentIsLoadingBooks = true;
            OnPropertyChanged(nameof(IsLoadingSpinnerVisible));

            Books.Clear();
            OnPropertyChanged(nameof(Books));

            this.searchText = searchText;
            int maxElements = (await _libraryService.GetBooksCountAsync(searchText)).Data;
            currentPage = page;
            maxPage = _libraryService.GetMaxPage(PageSize, maxElements);
            
            if (currentPage > maxPage)
            {
                currentPage = maxPage;
            }

            var booksResult = await _libraryService.SearchBooksAsync(searchText, currentPage, PageSize);
            if (booksResult.Success)
            {
                foreach (var p in booksResult.Data)
                {
                    Books.Add(p);
                }
            }
            else
            {
                Debug.WriteLine(">>>>>>>>>>>>>>>>!!!!!!!!!!!!!!!!!!!!!! GetBooks FAILED: " + booksResult.Message);
                if (IsLoggedUserVisible)
                {
                    _messageDialogService.ShowMessage(_translationsManager.Get(AppCurrentResources.Language, "RequestFailed") + booksResult.Message);
                }
            }

            currentIsLoadingBooks = false;
            OnPropertyChanged(nameof(IsLoadingSpinnerVisible));

            OnPropertyChanged(nameof(Books));
            OnPropertyChanged(nameof(IsBookListVisible));
            OnPropertyChanged(nameof(IsLoadingSpinnerVisible));
            OnPropertyChanged(nameof(CurrentPageText));
            OnPropertyChanged(nameof(IsNextButtonEnabled));
            OnPropertyChanged(nameof(IsPreviousButtonEnabled));
        }

        [RelayCommand]
        public void OpenLoginWindow()
        {
            LoginView loginView = _serviceProvider.GetService<LoginView>();
            LoginViewModel loginViewModel = _serviceProvider.GetService<LoginViewModel>();

            loginViewModel.SetIsLogin(true);
            loginView.Show();
        }

        [RelayCommand]
        public async void OpenRegisterWindow()
        {
            LoginView loginView = _serviceProvider.GetService<LoginView>();
            LoginViewModel loginViewModel = _serviceProvider.GetService<LoginViewModel>();

            loginViewModel.SetIsLogin(false);
            loginView.Show();
        }

        public async void GetAuthenticationState()
        {
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
        public async void Search(string searchText)
        {
            currentPage = 1;
            await GetBooks(searchText, currentPage);
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
        public void CreateBook()
        {
            BookFormView bookFormView = _serviceProvider.GetService<BookFormView>();
            BookFormViewModel bookFormViewModel = _serviceProvider.GetService<BookFormViewModel>();

            bookFormViewModel.SetEditingBook(-1);
            bookFormView.Show();
        }

        [RelayCommand]
        public void EditBook(string id)
        {
            BookFormView bookFormView = _serviceProvider.GetService<BookFormView>();
            BookFormViewModel bookFormViewModel = _serviceProvider.GetService<BookFormViewModel>();

            bookFormViewModel.SetEditingBook(int.Parse(id));
            bookFormView.Show();
        }

        public void CloseBookForm()
        {
            BookFormView bookFormView = _serviceProvider.GetService<BookFormView>();
            BookFormViewModel bookFormViewModel = _serviceProvider.GetService<BookFormViewModel>();
            bookFormView.Hide();

            GetBooks(searchText, currentPage);
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
                    " " + AuthenticationState?.User?.Claims?.Where(c => c.Type == "DateCreated")?.FirstOrDefault()?.Value) ;
            }
        }

        public bool IsLoggedUserVisible
        {
            get { return AppCurrentResources.Token != ""; }
        }

        public bool IsLoginButtonVisible
        {
            get { return AppCurrentResources.Token == ""; }
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

        public bool IsPolishLanguage
        {
            get { return AppCurrentResources.Language == "polish"; }
        }
        
        public bool IsEnglishLanguage
        {
            get { return AppCurrentResources.Language == "english"; }
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
            get { return currentPage < maxPage && IsLoggedUserVisible; }
        }

        public bool IsPreviousButtonEnabled
        {
            get { return currentPage > 1 && IsLoggedUserVisible; }
        }

        public bool IsBookListVisible
        {
            get { return Books.Count > 0; }
        }
        
        public bool IsLoadingSpinnerVisible
        {
            get { return currentIsLoadingBooks && IsLoggedUserVisible; }
        }

        public string YouMustBeLoggedInToSeeBooksMessageText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "YouMustBeLoggedInToSeeBooks"); }
        }

    }
}
