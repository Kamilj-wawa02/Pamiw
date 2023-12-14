using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using P04WeatherForecastAPI.Client.MessageBox;

using P04WeatherForecastAPI.Client.Services.SpeechService;
using P04WeatherForecastAPI.Client.Services.WeatherServices;
using P04WeatherForecastAPI.Client.ViewModels;
using P06Shop.Shared.Configuration;
using P06Shop.Shared.Languages;
using P06Shop.Shared.MessageBox;
using P06Shop.Shared.Services.AuthService;
using P06Shop.Shared.Services.LibraryService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace P04WeatherForecastAPI.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IServiceProvider _serviceProvider;
        IConfiguration _configuration;
        ITranslationsManager translationsManager;
        public App()
        {
            string s = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            //wczytanie appsettings.json do konfiguracji 
            var builder = new ConfigurationBuilder()
              .AddUserSecrets<App>()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true);
            _configuration = builder.Build();



            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();

        }

        private void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = ConfigureAppSettings(services);
            ConfigureAppServices(services);
            ConfigureViewModels(services);
            ConfigureViews(services);
            ConfigureHttpClients(services, appSettingsSection);
        }

        private AppSettings ConfigureAppSettings(IServiceCollection services)
        {
            // pobranie appsettings z konfiguracji i zmapowanie na klase AppSettings 
            //Microsoft.Extensions.Options.ConfigurationExtensions
            var appSettings = _configuration.GetSection(nameof(AppSettings));
            var appSettingsSection = appSettings.Get<AppSettings>();

            // services.Configure<AppSettings>(appSettings);
            services.AddSingleton(appSettingsSection);
            return appSettingsSection;
        }

        private void ConfigureAppServices(IServiceCollection services)
        {
            // konfiguracja serwisów 
            services.AddSingleton<IAccuWeatherService, AccuWeatherService>();
            services.AddSingleton<IFavoriteCityService, FavoriteCityService>();
            services.AddSingleton<ILibraryService, LibraryService>();
            services.AddSingleton<IMessageDialogService, WpfMesageDialogService>();


            services.AddSingleton<ITranslationsManager, TranslationsManager>();
            services.AddSingleton<ITranslationsManager>(translationsManager =>
            {
                //string workingDirectory = AppContext.BaseDirectory;
                //string projectDir = Directory.GetParent(workingDirectory).Parent.Parent.Parent.Parent.FullName;
                return new TranslationsManager(); //projectDir + "\\P06Shop.Shared\\Languages\\Translations");
            });
        }

        private void ConfigureViewModels(IServiceCollection services)
        {

            // konfiguracja viewModeli 
            services.AddSingleton<LibraryMainViewModel>();
            //services.AddSingleton<MainViewModelV4>();
            services.AddSingleton<FavoriteCityViewModel>();
            services.AddSingleton<BooksViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<LoginWithFacebookViewModel>();
            // services.AddSingleton<BaseViewModel,MainViewModelV3>();
        }

        private void ConfigureViews(IServiceCollection services)
        {
            // konfiguracja okienek
            services.AddTransient<LibraryMainWindow>();
            //services.AddTransient<MainWindow>();
            services.AddTransient<FavoriteCitiesView>();
            services.AddTransient<LibraryBooksView>();
            services.AddTransient<BookDetailsView>();
            services.AddTransient<LoginView>();
            services.AddTransient<LoginWithFacebookView>();
        }

        private void ConfigureHttpClients(IServiceCollection services, AppSettings appSettingsSection)
        {
            var uriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
            {
                //Path = appSettingsSection.BaseProductEndpoint.Base_url,
            };
            //Microsoft.Extensions.Http
            services.AddHttpClient<ILibraryService, LibraryService>(client => client.BaseAddress = uriBuilder.Uri);
            services.AddHttpClient<IAuthService, AuthService>(client => client.BaseAddress = uriBuilder.Uri);
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            AppCurrentResources.LoadSettings();
            
            //var mainWindow = _serviceProvider.GetService<MainWindow>();
            var mainWindow = _serviceProvider.GetService<LibraryMainWindow>();
            mainWindow.Show();
        }

    }
}
