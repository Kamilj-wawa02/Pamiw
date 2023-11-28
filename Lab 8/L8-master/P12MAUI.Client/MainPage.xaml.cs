using P04WeatherForecastAPI.Client.ViewModels;

namespace P12MAUI.Client
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage(BooksViewModel booksViewModel)
        {
            
            InitializeComponent();
            BindingContext = booksViewModel;
        }

       
    }
}