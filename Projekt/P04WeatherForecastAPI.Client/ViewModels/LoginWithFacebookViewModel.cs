using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using P06Shop.Shared.Auth;
using P06Shop.Shared.MessageBox;
using P06Shop.Shared.Services.AuthService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public partial class LoginWithFacebookViewModel : ObservableObject
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IAuthService _authService;
        private readonly IMessageDialogService _wpfMesageDialogService;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public static string Token { get; set; } = string.Empty;

        private string redirectionUrl = "https://localhost:7080/login-successful";

        private bool isLoading = false;

        [ObservableProperty]
        private string password = string.Empty;

        public LoginWithFacebookViewModel(IServiceProvider serviceProvider, IAuthService authService, IMessageDialogService wpfMesageDialogService,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _serviceProvider = serviceProvider;
            _authService = authService;
            _wpfMesageDialogService = wpfMesageDialogService;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public void BrowserReady()
        {
            SuppressCookiePersistence();

            LoginWithFacebookView loginWithFacebookView = _serviceProvider.GetService<LoginWithFacebookView>();
            WebBrowser webBrowser = loginWithFacebookView.webBrowser;

            string newUrl = _authService.LoginWithFacebookFormRedirection(redirectionUrl);
            Debug.WriteLine("LOADED BROWSER, navigating to: " + newUrl);
            webBrowser.Navigate(newUrl);

            SetLoading(true);
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

                Debug.WriteLine("LOGGED IN! NEW URL: " + currentUrl.ToString());
                Debug.WriteLine("LOGGED IN! token: " + token);

                //AppCurrentResources.SetToken(token);
                //await _authenticationStateProvider.GetAuthenticationStateAsync();

                LoginWithFacebookView loginWithFacebookView = _serviceProvider.GetService<LoginWithFacebookView>();
                WebBrowser webBrowser = loginWithFacebookView.webBrowser;
                webBrowser.Source = null;

                LoginViewModel loginViewModel = _serviceProvider.GetService<LoginViewModel>();
                loginViewModel.CloseLoginWithFacebookWindow();
                loginViewModel.LoggedIn(token);
            }
            else
            {
                Debug.WriteLine("NEW URL: " + currentUrl.ToString());
            }
        }

        public void SetLoading(bool loading)
        {
            isLoading = loading;
            OnPropertyChanged(nameof(IsLoadingSpinnerVisible));
        }

        public bool IsLoadingSpinnerVisible
        {
            get { return isLoading; }
        }



        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);

        private const int INTERNET_OPTION_SUPPRESS_BEHAVIOR = 81;
        private const int INTERNET_SUPPRESS_COOKIE_PERSIST = 3;

        public static void SuppressCookiePersistence()
        {
            var lpBuffer = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(int)));
            Marshal.StructureToPtr(INTERNET_SUPPRESS_COOKIE_PERSIST, lpBuffer, true);

            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SUPPRESS_BEHAVIOR, lpBuffer, sizeof(int));

            Marshal.FreeCoTaskMem(lpBuffer);
        }


    }

}
