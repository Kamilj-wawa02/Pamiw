using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P04Library.Client.Models;
using P06Library.Shared.MessageBox;
using P06Library.Shared.Services.LibraryService;
using P06Library.Shared.Library;
using P12MAUI.Client;
using P12MAUI.Client.ViewModels;
using P06Library.Shared.Auth;
using P06Library.Shared.Languages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Reflection.Metadata.BlobBuilder;
using System.Reflection;
using P06Library.Shared.Services.AuthService;
using Microsoft.AspNetCore.Components.Authorization;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace P12MAUI.Client.ViewModels
{
   
 public partial class LoginViewModel : ObservableObject
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IAuthService _authService;
        private readonly ITranslationsManager _translationsManager;
        private readonly IMessageDialogService _mesageDialogService;

        private bool IsLoginWithFacebook;
        private bool IsLoadingWebView;
        private bool IsLogin = false;

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
            Debug.WriteLine("SetIsLogin: " + _isLogin);
            IsLogin = _isLogin;
            RefreshAllProperties();
        }

        [RelayCommand]
        public async Task LoginRegister()
        {
            Debug.WriteLine("Logging in... with email: " + UserRegisterDTO.Email + " and password " + UserRegisterDTO.Password);

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

        private string redirectionUrl = "https://localhost:7080/login-successful";

        [RelayCommand]
        public async void OpenLoginWithFacebookWindow()
        {
            IsLoginWithFacebook = true;
            RefreshAllProperties();

            LoginView loginView = _serviceProvider.GetService<LoginView>();

            string newUrl = _authService.LoginWithFacebookFormRedirection(redirectionUrl);

            Debug.WriteLine("Starting Facebook Authentication, created URL: " + newUrl);
            loginView.NavigateWebView(newUrl);
            SetLoading(true);

            /*
            var authenticatorResult = await WebAuthenticator.AuthenticateAsync(new Uri(newUrl), new Uri(redirectionUrl));

            if (authenticatorResult.Properties.ContainsKey("code"))
            {
                var code = authenticatorResult.Properties["code"];

                var result = await _authService.LoginWithFacebook(code, redirectionUrl);
                if (!result.Success)
                {
                    _mesageDialogService.ShowMessage("Failed!");
                }

                var token = result.Data;
                _mesageDialogService.ShowMessage("Success: " + token);

            }
            */


            /*

            var facebookAuthUrl = new Uri($"https://www.facebook.com/v12.0/dialog/oauth?client_id=" + "884555979610977" + "&redirect_uri=" + redirectionUrl + "&response_type=token");

            var authenticatorResult = await WebAuthenticator.AuthenticateAsync(facebookAuthUrl, new Uri(redirectionUrl));

            // Otrzymaj dane z authenticatorResult
            if (authenticatorResult.Properties.TryGetValue("access_token", out var accessToken))
            {
                // Zalogowano pomyślnie, accessToken zawiera token dostępu
                // Możesz przekazać ten token do swojego serwera lub użyć go w inny sposób w twojej aplikacji
            }
            */



        }

        public void OnPageLoaded()
        {
            SetLoading(false);
        }

        public async void OnNewBrowserURL(string currentUrl)
        {
            Debug.WriteLine($"OnNewBrowserURL= {currentUrl}");

            if (currentUrl == null)
            {
                return;
            }

            if (currentUrl.StartsWith(redirectionUrl))
            {                
                Debug.WriteLine("LOGGED IN! NEW URL: " + currentUrl.ToString());
                
                string token = await _authService.ProcessUri(currentUrl, redirectionUrl);

                Debug.WriteLine("LOGGED IN! token: " + token);

                //AppCurrentResources.SetToken(token);
                //await _authenticationStateProvider.GetAuthenticationStateAsync();

                LoginView loginView = _serviceProvider.GetService<LoginView>();
                loginView.NavigateWebView(null);

                LoginViewModel loginViewModel = _serviceProvider.GetService<LoginViewModel>();
                loginViewModel.CloseLoginWithFacebookWindow();
                loginViewModel.LoggedIn(token);
            }
            else
            {
                Debug.WriteLine("NEW URL: " + currentUrl);
                //AcceptCookies();
            }
        }
        
        public void SetLoading(bool loading)
        {
            Debug.WriteLine($"SetLoading= {loading}");
            IsLoadingWebView = loading;
            OnPropertyChanged(nameof(IsLoadingSpinnerVisible));
        }

        [RelayCommand]
        public void CloseLoginWithFacebookWindow()
        {
            IsLoginWithFacebook = false;
            RefreshAllProperties();

            //LoginWithFacebookView libraryBooksView = _serviceProvider.GetService<LoginWithFacebookView>();
            //libraryBooksView.Hide();
        }

        public async void CloseLoginWindow()
        {
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PopAsync();
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

        public bool IsLoadingSpinnerVisible
        {
            get { return IsLoadingWebView; }
        }
        public bool IsLoginWithFacebookInvisible
        {
            get { return !IsLoginWithFacebook; }
        }

        public bool IsNormalLoginRegisterInvisible
        {
            get { return IsLoginWithFacebook; }
        }

        public bool IsRegistrationHidden
        {
            get { return IsLogin; }
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
