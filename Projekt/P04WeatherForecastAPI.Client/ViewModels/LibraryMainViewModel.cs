using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using P04WeatherForecastAPI.Client.Commands;
using P04WeatherForecastAPI.Client.DataSeeders;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services.WeatherServices;
using P06Shop.Shared.Languages;
using P06Shop.Shared.Library;
using P06Shop.Shared.MessageBox;
using P06Shop.Shared.Services.LibraryService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    // przekazywanie wartosci do innego formularza 
    public partial class LibraryMainViewModel : ObservableObject
    {
        private readonly int PageSize = 10;

        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageDialogService _messageDialogService;
        private readonly ITranslationsManager _translationsManager;
        private readonly ILibraryService _libraryService;

        [ObservableProperty]
        private Book selectedBook;
        public ObservableCollection<Book> Books { get; set; }

        public LibraryMainViewModel(IServiceProvider serviceProvider, IMessageDialogService messageDialogService, ITranslationsManager translationsManager, ILibraryService libraryService)
        {
            _serviceProvider = serviceProvider;
            _messageDialogService = messageDialogService;
            _translationsManager = translationsManager;
            _libraryService = libraryService;

            Books = new ObservableCollection<Book>();
        }

        public async Task GetBooks(string searchText)
        {
            Books.Clear();
            var booksResult = await _libraryService.SearchBooksAsync(searchText, currentPage, PageSize);
            if (booksResult.Success)
            {
                foreach (var p in booksResult.Data)
                {
                    Books.Add(p);
                }
                OnPropertyChanged(nameof(Books));
                OnPropertyChanged(nameof(IsBookListVisible));
            }
        }

        [RelayCommand]
        public void OpenLibraryWindow()
        {
            if (!string.IsNullOrEmpty(LoginViewModel.Token))
            {
                LibraryBooksView libraryBooksView = _serviceProvider.GetService<LibraryBooksView>();
                BooksViewModel libraryBooksViewModel = _serviceProvider.GetService<BooksViewModel>();

                libraryBooksView.Show();
                libraryBooksViewModel.GetBooks();
            }
            else
            {
                _messageDialogService.ShowMessage("Access denied! Log in first!");
            }
        }

        [RelayCommand]
        public void OpenLoginWindow()
        {
            LoginView loginView = _serviceProvider.GetService<LoginView>();
            LoginViewModel loginViewModel = _serviceProvider.GetService<LoginViewModel>();

            loginView.Show();
            //_messageDialogService.ShowMessage("v: " + CurrentThemeIcon);
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
            Debug.WriteLine("Switching language!!!");
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
            await GetBooks(searchText);
        }

        [RelayCommand]
        public void PreviousPage()
        {
            currentPage--;
            OnPropertyChanged(nameof(CurrentPageText));
            OnPropertyChanged(nameof(IsNextButtonEnabled));
            OnPropertyChanged(nameof(IsPreviousButtonEnabled));
        }

        [RelayCommand]
        public void NextPage()
        {
            currentPage++;
            OnPropertyChanged(nameof(CurrentPageText));
            OnPropertyChanged(nameof(IsNextButtonEnabled));
            OnPropertyChanged(nameof(IsPreviousButtonEnabled));
        }

        private int currentPage = 1;
        private int maxPage = 2;

        public string LibraryText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "Library"); }
        }

        public string OpenBookListText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "OpenBookList"); }
        }

        public string LoginText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "Login"); }
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
            get { return currentPage < maxPage; }
        }

        public bool IsPreviousButtonEnabled
        {
            get { return currentPage > 1; }
        }

        public bool IsBookListVisible
        {
            get { return Books.Count > 0; }
        }

    }
}
