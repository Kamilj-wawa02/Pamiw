using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P04WeatherForecastAPI.Client.Models;
using P06Shop.Shared.MessageBox;
using P06Shop.Shared.Services.LibraryService;
using P06Shop.Shared.Library;
using P12MAUI.Client;
using P12MAUI.Client.ViewModels;
using P06Shop.Shared.Auth;
using P06Shop.Shared.Languages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Reflection.Metadata.BlobBuilder;
using System.Reflection;
using P06Shop.Shared.Services.AuthService;
using Microsoft.AspNetCore.Components.Authorization;
using System.Diagnostics;

namespace P12MAUI.Client.ViewModels
{
   
 public partial class LoginViewModel : ObservableObject
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IAuthService _authService;
        private readonly ITranslationsManager _translationsManager;
        private readonly IMessageDialogService _mesageDialogService;

        private bool IsLogin = false;

        [ObservableProperty]
        private string password = string.Empty;

        public LoginViewModel(IServiceProvider serviceProvider, IAuthService authService, ITranslationsManager translationsManager,
            IMessageDialogService wpfMesageDialogService, AuthenticationStateProvider authenticationStateProvider)
        {
            UserRegisterDTO = new UserRegisterDTO();
            _serviceProvider = serviceProvider;
            _authService = authService;
            _translationsManager = translationsManager;
            _mesageDialogService = wpfMesageDialogService;
        }

        [ObservableProperty]
        private UserRegisterDTO userRegisterDTO;

        public void SetIsLogin(bool _isLogin)
        {
            IsLogin = _isLogin;
            RefreshAllProperties();

            LoginView loginView = _serviceProvider.GetService<LoginView>();
        }

        public async Task LoginRegister(string password, string confirmPassword)
        {
            Debug.WriteLine("Logging in... with email: " + UserRegisterDTO.Email + " and password " + password);

            UserRegisterDTO.Password = password;
            UserRegisterDTO.ConfirmPassword = confirmPassword;

            if (string.IsNullOrEmpty(UserRegisterDTO.Email) || string.IsNullOrEmpty(UserRegisterDTO.Password))
            {
                _mesageDialogService.ShowMessage(_translationsManager.Get(AppCurrentResources.Language, "EmptyData"));
                return;
            }

            if (IsLogin)
            {
                UserLoginDTO userLoginDTO = new UserLoginDTO();
                userLoginDTO.Email = UserRegisterDTO.Email;
                userLoginDTO.Password = UserRegisterDTO.Password;

                var response = await _authService.Login(userLoginDTO);

                if (response.Success)
                {
                    LoggedIn(response.Data);
                }
                else
                {
                    LoggedOut();
                    _mesageDialogService.ShowMessage(_translationsManager.Get(AppCurrentResources.Language, "LoginFailed") + "\n" + response.Message);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(UserRegisterDTO.Username) || string.IsNullOrEmpty(UserRegisterDTO.ConfirmPassword))
                {
                    _mesageDialogService.ShowMessage(_translationsManager.Get(AppCurrentResources.Language, "EmptyData"));
                    return;
                }

                if (!UserRegisterDTO.Email.Contains("@") || UserRegisterDTO.Password.Length < 6)
                {
                    _mesageDialogService.ShowMessage(_translationsManager.Get(AppCurrentResources.Language, "WrongLoginDataMessage"));
                    return;
                }

                if (UserRegisterDTO.Password != UserRegisterDTO.ConfirmPassword)
                {
                    _mesageDialogService.ShowMessage(_translationsManager.Get(AppCurrentResources.Language, "NotTheSamePasswords"));
                    return;
                }

                var response = await _authService.Register(UserRegisterDTO);

                if (response.Success)
                {
                    SetIsLogin(true);
                    _mesageDialogService.ShowMessage(_translationsManager.Get(AppCurrentResources.Language, "RegisteredSuccessfully"));
                }
                else
                {
                    _mesageDialogService.ShowMessage(_translationsManager.Get(AppCurrentResources.Language, "RegistrationFailed") + "\n" + response.Message);
                }

            }


        }

        public async Task LoggedIn(string token)
        {
            Debug.WriteLine("Logged in!");

            AppCurrentResources.SetToken(token);
            MainViewModel mainViewModel = _serviceProvider.GetService<MainViewModel>();
            mainViewModel.GetAuthenticationState();
            CloseLoginWindow();
        }

        public async Task LoggedOut()
        {
            AppCurrentResources.SetToken("");
            MainViewModel mainViewModel = _serviceProvider.GetService<MainViewModel>();
            mainViewModel.GetAuthenticationState();

        }


        [RelayCommand]
        public void OpenLoginWithFacebookWindow()
        {
            //LoginWithFacebookView libraryBooksView = _serviceProvider.GetService<LoginWithFacebookView>();
            //libraryBooksView.Show();
        }

        public void CloseLoginWithFacebookWindow()
        {
            //LoginWithFacebookView libraryBooksView = _serviceProvider.GetService<LoginWithFacebookView>();
            //libraryBooksView.Hide();
        }

        public void CloseLoginWindow()
        {
            //LoginView loginView = _serviceProvider.GetService<LoginView>();
            //loginView.Hide();

            MainViewModel mainViewModel = _serviceProvider.GetService<MainViewModel>();
            mainViewModel.RefreshAllProperties();
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

        public bool IsRegistrationDisplayed
        {
            get { return !IsLogin; }
        }

        public string LoginText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, IsLogin ? "Login" : "Register"); }
        }

        public string EmailText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "Email"); }
        }

        public string PasswordText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "Password"); }
        }

        public string UsernameText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "Username"); }
        }

        public string ConfirmPasswordText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "ConfirmPassword"); }
        }

        public string LoginWithFacebookText
        {
            get { return _translationsManager.Get(AppCurrentResources.Language, "LoginWithFacebook"); }
        }

    }
}
