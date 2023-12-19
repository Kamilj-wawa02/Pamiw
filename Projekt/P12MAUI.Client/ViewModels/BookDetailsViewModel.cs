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
using P06Shop.Shared.Languages;

namespace P12MAUI.Client.ViewModels
{
    [QueryProperty(nameof(Book), nameof(Book))]
    [QueryProperty(nameof(MainViewModel), nameof(MainViewModel))]
    public partial class BookDetailsViewModel : ObservableObject
    {
        private readonly ILibraryService _libraryService;
        private readonly ITranslationsManager _translationsManager;
        private readonly IMessageDialogService _messageDialogService;
        private readonly IGeolocation _geolocation;
        private readonly IMap _map;
        private MainViewModel _mainViewModel;

        public BookDetailsViewModel(ILibraryService libraryService, ITranslationsManager translationsManager,
            IMessageDialogService messageDialogService, IGeolocation geolocation, IMap map)
        {
            _map = map;
            _translationsManager = translationsManager;
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
            if (result.Success)
                await _mainViewModel.GetBooks();
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
            //await _mainViewModel.GetBooks();
        }


        [RelayCommand]
        public async Task Save()
        {
            if (book.Id == 0)
            {
                CreateBook();
            }
            else
            {
                UpdateBook();
            }

            CloseDetails();
        }

        [RelayCommand]
        public async Task Delete()
        {
            DeleteBook();
            CloseDetails();
        }

        public async void CloseDetails()
        {
            await Shell.Current.GoToAsync("../", true);
            _mainViewModel.GetBooks();
        }

        public string TitleText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "Title"); }
        }

        public string AuthorText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "Author"); }
        }

        public string DescriptionText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "Description"); }
        }

        public string BarcodeText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "Barcode"); }
        }

        public string PriceText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "Price"); }
        }

        public string ReleaseDateText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "ReleaseDate"); }
        }

        public string IdText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "Title"); }
        }

    }
}
