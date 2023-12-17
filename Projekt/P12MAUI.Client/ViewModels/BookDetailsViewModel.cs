using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel;
using P12MAUI.Client.ViewModels;
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
    [QueryProperty(nameof(MainViewModel), nameof(MainViewModel))]
    public partial class BookDetailsViewModel : ObservableObject
    {
        private readonly ILibraryService _libraryService;
        private readonly IMessageDialogService _messageDialogService;
        private readonly IGeolocation _geolocation;
        private readonly IMap _map;
        private MainViewModel _mainViewModel;

        public BookDetailsViewModel(ILibraryService libraryService, IMessageDialogService messageDialogService, IGeolocation geolocation, IMap map)
        {
            _map = map;
            _libraryService = libraryService;
            _messageDialogService = messageDialogService;
            _geolocation = geolocation;
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return _mainViewModel;
            }
            set
            {
                _mainViewModel = value;
            }
        }


        [ObservableProperty]
        Book book;

        public async Task DeleteBook()
        {
            await _libraryService.DeleteBookAsync(book.Id);
            //await _mainViewModel.GetBooks();
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
            //if (result.Success)
            //    await _mainViewModel.GetBooks();
            //else
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
            //await _mainViewModel.GetBooks();
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
