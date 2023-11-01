using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services.LibraryServices;
using P06Shop.Shared.Services.LibraryService;
using P06Shop.Shared.Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Diagnostics;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public partial class LibraryBooksViewModel : ObservableObject
    {
        private readonly ILibraryService _libraryService;

        private int _currentPage = 1;
        public List<Book> AllBooks { get; set; }
        public ObservableCollection<Book> PageBooks { get; set; }

        public LibraryBooksViewModel(ILibraryService libraryService)
        {
            _libraryService = libraryService;
            PageBooks = new ObservableCollection<Book>();
            AllBooks = new List<Book>();
        }

        public async void GetBooks()
        {
            AllBooks.Clear();
            var booksResult = await _libraryService.GetBooksAsync();
            if (booksResult.Success)
            {
                foreach (var p in booksResult.Data)
                {
                    AllBooks.Add(p);
                }
                LoadBooksOnPage();
            }
        }

        public void LoadBooksOnPage()
        {
            PageBooks.Clear();
            
            int ItemsPerPage = 4;
     
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

    }
}
