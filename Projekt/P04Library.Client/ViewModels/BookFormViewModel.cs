using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using P04Library.Client.Commands;
using P04Library.Client.DataSeeders;
using P04Library.Client.Models;
using P04Library.Client.Services.WeatherServices;
using P06Library.Shared.Languages;
using P06Library.Shared.Library;
using P06Library.Shared.MessageBox;
using P06Library.Shared.Services.LibraryService;
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

namespace P04Library.Client.ViewModels
{
    // przekazywanie wartosci do innego formularza 
    public partial class BookFormViewModel : ObservableObject
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageDialogService _messageDialogService;
        private readonly ITranslationsManager _translationsManager;
        private readonly ILibraryService _libraryService;

        private string searchText = "";

        [ObservableProperty]
        private Book currentBook;

        private bool isEditing;

        public BookFormViewModel(IServiceProvider serviceProvider, IMessageDialogService messageDialogService, ITranslationsManager translationsManager, ILibraryService libraryService)
        {
            _serviceProvider = serviceProvider;
            _messageDialogService = messageDialogService;
            _translationsManager = translationsManager;
            _libraryService = libraryService;

            CurrentBook = new Book();
            isEditing = false;
        }

        public async void SetEditingBook(int id)
        {
            var result = (id < 0 ? null : await _libraryService.GetBookByIdAsync(id));
            
            if (result != null && result.Success)
            {
                isEditing = true;
                currentBook = result.Data;
            }
            else
            {
                isEditing = false;
                currentBook = new Book();
            }

            OnPropertyChanged(nameof(CurrentBook));
            OnPropertyChanged(nameof(IsEditingEnabled));
            OnPropertyChanged(nameof(SaveText));
        }

        [RelayCommand]
        public async void Save()
        {
            if (string.IsNullOrEmpty(CurrentBook.Title) || string.IsNullOrEmpty(CurrentBook.Author) ||
                string.IsNullOrEmpty(CurrentBook.Description) || string.IsNullOrEmpty(CurrentBook.Barcode))
            {
                _messageDialogService.ShowMessage(_translationsManager.Get(AppCurrentResources.Language, "EmptyData"));
                return;
            }

            if (!isEditing)
            {
                var result = await _libraryService.CreateBookAsync(CurrentBook);
                if (!result.Success)
                {
                    _messageDialogService.ShowMessage(_translationsManager.Get(AppCurrentResources.Language, "FailedCreatingBook") + "\n" + result.Message);
                    return;
                }
            }
            else
            {
                var result = await _libraryService.UpdateBookAsync(CurrentBook);
                if (!result.Success)
                {
                    _messageDialogService.ShowMessage(_translationsManager.Get(AppCurrentResources.Language, "FailedUpdatingBook") + "\n" + result.Message);
                    return;
                }
            }

            CloseWindow();
        }

        [RelayCommand]
        public async void Delete()
        {
            var result = await _libraryService.DeleteBookAsync(CurrentBook.Id);
            if (!result.Success)
            {
                _messageDialogService.ShowMessage(_translationsManager.Get(AppCurrentResources.Language, "FailedDeletingBook") + "\n" + result.Message);
                return;
            }

            CloseWindow();
        }

        public void CloseWindow()
        {
            LibraryMainViewModel libraryMainViewModel = _serviceProvider.GetService<LibraryMainViewModel>();
            libraryMainViewModel.CloseBookForm();
        }


        public string SaveText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, isEditing ? "Save" : "CreateBook"); }
        }

        public string DeleteText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "Delete"); }
        }

        public bool IsEditingEnabled
        {
            get { return isEditing; }
        }


    }
}
