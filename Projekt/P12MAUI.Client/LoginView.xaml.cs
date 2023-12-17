using P12MAUI.Client.ViewModels;
using System.Diagnostics;

namespace P12MAUI.Client;

public partial class LoginView : ContentPage
{
    private LoginViewModel loginViewModel;
    public LoginView(LoginViewModel _loginViewModel)
	{
		BindingContext = _loginViewModel;
        loginViewModel = _loginViewModel;
        InitializeComponent();
    }

    private void Navigating(object sender, WebNavigatingEventArgs e)
    {
        loginViewModel.OnNewBrowserURL(e.Url);
    }

    private void Navigated(object sender, WebNavigatedEventArgs e)
    {
        loginViewModel.OnPageLoaded();
    }

    public void NavigateWebView(string url)
    {
        webView.Source = (string.IsNullOrEmpty(url) ? null : new Uri(url));
    }

}