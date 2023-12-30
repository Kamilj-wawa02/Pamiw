using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using P04Library.Client.MessageBox;
using P04Library.Client.Services.CustomAuthStateProvider;
using P04Library.Client.Services.SpeechService;
using P04Library.Client.Services.WeatherServices;
using P04Library.Client.ViewModels;
using P06Library.Shared.Configuration;
using P06Library.Shared.Languages;
using P06Library.Shared.MessageBox;
using P06Library.Shared.Services.AuthService;
using P06Library.Shared.Services.LibraryService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace P04Library.Client
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
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production" ? "Production" : "Development";
            //env = "Development";//"Production";
            Debug.WriteLine(">>> Current configuration: '" + env + "'");
            //wczytanie appsettings.json do konfiguracji 
            var builder = new ConfigurationBuilder()
              .AddUserSecrets<App>()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .AddJsonFile($"appsettings.{env}.json");
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

            //appSettingsSection.BaseAPIUrl = "https://handy-freedom-408622.nw.r.appspot.com";

            Debug.WriteLine($">>>>>> API BaseURL: {appSettingsSection.BaseAPIUrl}");

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
                return new TranslationsManager(); //projectDir + "\\P06Library.Shared\\Languages\\Translations");
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
            services.AddSingleton<BookFormViewModel>();
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

            services.AddSingleton<LoginView>();
            services.AddSingleton<LoginWithFacebookView>();
            services.AddSingleton<BookFormView>();
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

            services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            AppCurrentResources.LoadSettings();
            
            //var mainWindow = _serviceProvider.GetService<MainWindow>();
            var mainWindow = _serviceProvider.GetService<LibraryMainWindow>();
            mainWindow.Show();

            //int browserVer = 11;
            //RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            //regKey.SetValue(Process.GetCurrentProcess().ProcessName + ".exe", browserVer, RegistryValueKind.DWord);
            //regKey.Close();
        }

    }
}
