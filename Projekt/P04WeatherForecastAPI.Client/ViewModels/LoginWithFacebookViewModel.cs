using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using P06Shop.Shared.Auth;
using P06Shop.Shared.MessageBox;
using P06Shop.Shared.Services.AuthService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public partial class LoginWithFacebookViewModel : ObservableObject
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IAuthService _authService;
        private readonly IMessageDialogService _wpfMesageDialogService;
        public static string Token { get; set; } = string.Empty;

        private string redirectionUrl = "https://localhost:7080/login-successful";


        [ObservableProperty]
        private string password = string.Empty;

        public LoginWithFacebookViewModel(IServiceProvider serviceProvider, IAuthService authService, IMessageDialogService wpfMesageDialogService)
        {
            _serviceProvider = serviceProvider;
            _authService = authService;
            _wpfMesageDialogService = wpfMesageDialogService;
        }

        public void BrowserReady()
        {
            LoginWithFacebookView loginWithFacebookView = _serviceProvider.GetService<LoginWithFacebookView>();
            WebBrowser webBrowser = loginWithFacebookView.webBrowser;

            string newUrl = _authService.LoginWithFacebookFormRedirection(redirectionUrl);
            Debug.WriteLine("LOADED BROWSER, navigating to: " + newUrl);
            webBrowser.Navigate(newUrl);
        }

        public async void BrowserUriUpdated(Uri currentUrl)
        {
            if (currentUrl == null)
            {
                return;
            }

            if (currentUrl.AbsoluteUri.ToString().StartsWith(redirectionUrl))
            {
                string token = await _authService.ProcessUri(currentUrl.AbsoluteUri.ToString(), redirectionUrl);

                Debug.WriteLine("LOGGED IN!!!! NEW URL: " + currentUrl.ToString());
                Debug.WriteLine("LOGGED IN! token: " + token);

                AppCurrentResources.SetToken(token);

                LoginWithFacebookView loginWithFacebookView = _serviceProvider.GetService<LoginWithFacebookView>();
                WebBrowser webBrowser = loginWithFacebookView.webBrowser;
                webBrowser.Source = null;

                LoginViewModel loginViewModel = _serviceProvider.GetService<LoginViewModel>();
                loginViewModel.CloseLoginWithFacebookWindow();
            }
            else
            {
                Debug.WriteLine("NEW URL: " + currentUrl.ToString());
            }
        }




    }

}
