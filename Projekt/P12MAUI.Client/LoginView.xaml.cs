using P12MAUI.Client.ViewModels;

namespace P12MAUI.Client;

public partial class LoginView : ContentView
{
	public LoginView(LoginViewModel loginViewModel)
	{
		BindingContext = loginViewModel;
        InitializeComponent();
	}

    private void Button_Click(object sender, EventArgs e)
    {

    }
}