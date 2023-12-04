using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services.SpeechService;
using P04WeatherForecastAPI.Client.Services.WeatherServices;
using P06Shop.Shared.MessageBox;
using P06Shop.Shared.Services.LibraryService;
using P06Shop.Shared.Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Diagnostics;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public partial class BooksViewModel : ObservableObject
    {
        private readonly ILibraryService _libraryService;
        private readonly BookDetailsView _bookDetailsView;
        private readonly IMessageDialogService _messageDialogService;

        private int _currentPage = 1;
        public List<Book> AllBooks { get; set; }
        public ObservableCollection<Book> PageBooks { get; set; }

        [ObservableProperty]
        private Book selectedBook;



        public BooksViewModel(ILibraryService libraryService, BookDetailsView booksDetailsView, IMessageDialogService messageDialogService)
        {
            _libraryService = libraryService;
            _messageDialogService = messageDialogService;
            _bookDetailsView = booksDetailsView;
            PageBooks = new ObservableCollection<Book>();
            AllBooks = new List<Book>();
        }

        public async Task GetBooks()
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






        public async Task<bool> CreateBook()
        {
            var newBook  = new Book()
            {
                Title = selectedBook.Title,
                Author = selectedBook.Author,
                Description = selectedBook.Description,
                Barcode = selectedBook.Barcode,
                Price = selectedBook.Price,
                ReleaseDate = selectedBook.ReleaseDate,
            };

            Debug.WriteLine("CreateBook " + newBook.Title);
            var result = await _libraryService.CreateBookAsync(newBook);
            if (result.Success)
            {
                Debug.WriteLine("CreatedBook!!!");
                await GetBooks();
                return true;
            }
            else
            {
                _messageDialogService.ShowMessage(result.Message);
                return false;
            }
        }

        public async Task<bool> UpdateBook()
        {
            var bookToUpdate = new Book()
            {
                Id = selectedBook.Id,
                Title = selectedBook.Title,
                Author = selectedBook.Author,
                Description = selectedBook.Description,
                Barcode = selectedBook.Barcode,
                Price = selectedBook.Price,
                ReleaseDate = selectedBook.ReleaseDate,
            };

            Debug.WriteLine("UpdateBook " + bookToUpdate.Title);

            var res = await _libraryService.UpdateBookAsync(bookToUpdate);
            GetBooks();

            if (!res.Success)
            {
                _messageDialogService.ShowMessage(res.Message);
            }

            return res.Success;
        }

        public async Task<bool> DeleteBook()
        {
            Debug.WriteLine("DeleteBook " + selectedBook.Title);
            var res = await _libraryService.DeleteBookAsync(selectedBook.Id);
            await GetBooks();

            if (!res.Success)
            {
                _messageDialogService.ShowMessage(res.Message);
            }

            return res.Success;
        }

        [RelayCommand]
        public async Task ShowDetails(Book product)
        {
            _bookDetailsView.Show();
            _bookDetailsView.DataContext = this;
            //selectedBook = product;
            //OnPropertyChanged("SelectedBook");
            SelectedBook = product;
        }


        [RelayCommand]
        public async Task Save()
        {
            bool success;
            if (selectedBook.Id == 0)
            {
                success = await CreateBook();
            }
            else
            {
                success = await UpdateBook();
            }
            if (success)
                _bookDetailsView.Hide();
        }

        [RelayCommand]
        public async Task Delete()
        {
            bool success = await DeleteBook();
            if (success)
            {
                _bookDetailsView.Hide();
            }
        }

        [RelayCommand]
        public async Task New()
        {
            _bookDetailsView.Show();
            _bookDetailsView.DataContext = this;
            //selectedBook = new Book();
            //OnPropertyChanged("SelectedBook");
            SelectedBook = new Book();
        }

    }
}
