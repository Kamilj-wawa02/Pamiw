using P04Library.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace P04Library.Client
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWithFacebook.xaml
    /// </summary>
    public partial class LoginWithFacebookView : Window
    {
        private readonly LoginWithFacebookViewModel _loginWithFacebookViewModel;
        public LoginWithFacebookView(LoginWithFacebookViewModel loginWithFacebookViewModel)
        {
            _loginWithFacebookViewModel = loginWithFacebookViewModel;
            DataContext = loginWithFacebookViewModel;
            InitializeComponent();
        }

        private void webBrowser_Loaded(object sender, RoutedEventArgs e)
        {
            _loginWithFacebookViewModel.BrowserReady();
        }

        private void webBrowser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            _loginWithFacebookViewModel.SetLoading(true);
            _loginWithFacebookViewModel.BrowserUriUpdated(e.Uri);
        }

        private void webBrowser_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            _loginWithFacebookViewModel.SetLoading(false);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool) e.NewValue)
            {
                _loginWithFacebookViewModel.BrowserReady();
            }
        }
    }


}
