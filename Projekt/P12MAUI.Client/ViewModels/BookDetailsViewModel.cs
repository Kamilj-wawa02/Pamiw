using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel;
using P12MAUI.Client.ViewModels;
using P06Library.Shared.MessageBox;
using P06Library.Shared.Services.LibraryService;
using P06Library.Shared.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P06Library.Shared.Languages;

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
                OnPropertyChanged(nameof(DeleteButtonInvisible));
            }
        }


        [ObservableProperty]
        Book book;

        public async Task DeleteBook()
        {
            var result = await _libraryService.DeleteBookAsync(book.Id);
            if (!result.Success)
            {
                _messageDialogService.ShowMessage(_translationsManager.Get(AppCurrentResources.Language, "RequestFailed") + result.Message);
            }
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
            if (!result.Success)
            {
                //_messageDialogService.ShowMessage(result.Message);
                _messageDialogService.ShowMessage(_translationsManager.Get(AppCurrentResources.Language, "RequestFailed") + result.Message);
            }
                
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

            var result =  await _libraryService.UpdateBookAsync(bookToUpdate);
            if (!result.Success)
            {
                _messageDialogService.ShowMessage(_translationsManager.Get(AppCurrentResources.Language, "RequestFailed") + result.Message);
            }
            //await _mainViewModel.GetBooks();
        }


        [RelayCommand]
        public async Task Save()
        {
            if (book.Id == 0)
            {
                await CreateBook();
            }
            else
            {
                await UpdateBook();
            }

            CloseDetails();
        }

        [RelayCommand]
        public async Task Delete()
        {
            await DeleteBook();
            CloseDetails();
        }

        public async void CloseDetails()
        {
            await Shell.Current.GoToAsync("../", true);
            _mainViewModel.GetBooks();
        }

        public bool DeleteButtonInvisible
        {
            get { return Book == null ? false : (Book.Id != 0); }
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
