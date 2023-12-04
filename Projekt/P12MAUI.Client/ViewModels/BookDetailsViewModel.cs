using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel;
using P04WeatherForecastAPI.Client.ViewModels;
using P06Shop.Shared.MessageBox;
using P06Shop.Shared.Services.LibraryService;
using P06Shop.Shared.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P12MAUI.Client.ViewModels
{
    [QueryProperty(nameof(Book), nameof(Book))]
    [QueryProperty(nameof(BooksViewModel), nameof(BooksViewModel))]
    public partial class BookDetailsViewModel : ObservableObject
    {
        private readonly ILibraryService _libraryService;
        private readonly IMessageDialogService _messageDialogService;
        private readonly IGeolocation _geolocation;
        private readonly IMap _map;
        private BooksViewModel _bookViewModel;

        public BookDetailsViewModel(ILibraryService libraryService, IMessageDialogService messageDialogService, IGeolocation geolocation, IMap map)
        {
            _map = map;
            _libraryService = libraryService;
            _messageDialogService = messageDialogService;
            _geolocation = geolocation;
        }

        public BooksViewModel BooksViewModel
        {
            get
            {
                return _bookViewModel;
            }
            set
            {
                _bookViewModel = value;
            }
        }


        [ObservableProperty]
        Book book;

        public async Task DeleteBook()
        {
            await _libraryService.DeleteBookAsync(book.Id);
            await _bookViewModel.GetBooks();
        }

        public async Task CreateBook()
        {
            var newBook = new Book()
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Barcode = book.Barcode,
                Price = book.Price,
                ReleaseDate = book.ReleaseDate,
            };

            var result = await _libraryService.CreateBookAsync(newBook);
            if (result.Success)
                await _bookViewModel.GetBooks();
            else
                _messageDialogService.ShowMessage(result.Message);
        }

        public async Task UpdateBook()
        {
            var bookToUpdate = new Book()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Barcode = book.Barcode,
                Price = book.Price,
                ReleaseDate = book.ReleaseDate,
            };

            await _libraryService.UpdateBookAsync(bookToUpdate);
            await _bookViewModel.GetBooks();
        }


        [RelayCommand]
        public async Task Save()
        {
            if (book.Id == 0)
            {
                CreateBook();
                await Shell.Current.GoToAsync("../", true);

            }
            else
            {
                UpdateBook();
                await Shell.Current.GoToAsync("../", true);
            }

        }

        [RelayCommand]
        public async Task Delete()
        {
            DeleteBook();
            await Shell.Current.GoToAsync("../", true);
        }
    }
}
