using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P04WeatherForecastAPI.Client.Models;
using P06Shop.Shared.MessageBox;
using P06Shop.Shared.Services.LibraryService;
using P06Shop.Shared.Library;
using P12MAUI.Client;
using P12MAUI.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Reflection.Metadata.BlobBuilder;
using System.Reflection;

namespace P04WeatherForecastAPI.Client.ViewModels
{
   
 public partial class BooksViewModel : ObservableObject
    {
        private readonly ILibraryService _libraryService;
        private readonly BookDetailsView _bookDetailsView;
        private readonly IMessageDialogService _messageDialogService;
        private readonly IConnectivity _connectivity;

        private int _currentPage = 1;
        public List<Book> AllBooks { get; set; }
        public ObservableCollection<Book> PageBooks { get; set; }

        [ObservableProperty]
        private Book selectedBook;

        public BooksViewModel(ILibraryService libraryService, BookDetailsView bookDetailsView, IMessageDialogService messageDialogService,
            IConnectivity connectivity)
        {
            _messageDialogService = messageDialogService;
            _bookDetailsView = bookDetailsView;
            _libraryService = libraryService;
            _connectivity = connectivity; // set the _connectivity field
            PageBooks = new ObservableCollection<Book>();
            AllBooks = new List<Book>();
            GetBooks();
        }

        public async Task GetBooks()
        {
            AllBooks.Clear();
            
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                _messageDialogService.ShowMessage("Internet not available!");
                return;
            }
            
            var booksResult = await _libraryService.GetBooksAsync();
            if (booksResult.Success)
            {
                foreach (var p in booksResult.Data)
                {
                    AllBooks.Add(p);
                }
                LoadBooksOnPage();
            }
            else
            {
                _messageDialogService.ShowMessage(booksResult.Message);
            }
        }

        public void LoadBooksOnPage()
        {
            PageBooks.Clear();

            int ItemsPerPage = 7;

            MaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(AllBooks.Count) / Convert.ToDouble(ItemsPerPage)));
            if (MaxPage == 0)
            {
                MaxPage = 1;
            }

            for (int i = (CurrentPage - 1) * ItemsPerPage; i < (CurrentPage - 1) * ItemsPerPage + ItemsPerPage; i++)
            {
                if (i > AllBooks.Count - 1)
                {
                    break;
                }
                PageBooks.Add(AllBooks[i]);
            }
        }

        [ObservableProperty]
        public int maxPage;

        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                LoadBooksOnPage();
                OnPropertyChanged();
            }
        }

        [RelayCommand]
        public async void NextPage()
        {
            if (CurrentPage < MaxPage)
            {
                CurrentPage++;
                LoadBooksOnPage();
                OnPropertyChanged();
            }
        }

        [RelayCommand]
        public async void PreviousPage()
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                LoadBooksOnPage();
                OnPropertyChanged();
            }
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
                {nameof(BooksViewModel), this }
            });
            SelectedBook = book;
        }

        [RelayCommand]
        public async Task New()
        {
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                _messageDialogService.ShowMessage("Internet not available!");
                return;
            }

            SelectedBook = new Book();
            await Shell.Current.GoToAsync(nameof(BookDetailsView), true, new Dictionary<string, object>
            {
                {"Book", SelectedBook },
                {nameof(BooksViewModel), this }
            });
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

    }
}
