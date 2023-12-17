using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using P12MAUI.Client;
using P12MAUI.Client.ViewModels;
using P06Shop.Shared.Configuration;
using P06Shop.Shared.MessageBox;
using P06Shop.Shared.Services.AuthService;
using P06Shop.Shared.Services.LibraryService;
using P12MAUI.Client.MessageBox;
using System.Diagnostics;
using P06Shop.Shared.Languages;
using Microsoft.AspNetCore.Components.Authorization;
using P12MAUI.Client.Services.CustomAuthStateProvider;

namespace P12MAUI.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            ConfigureServices(builder.Services);
            return builder.Build();
        }


        private static void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = ConfigureAppSettings(services);
            ConfigureAppServices(services, appSettingsSection);
            ConfigureViewModels(services);
            ConfigureViews(services);
            ConfigureHttpClients(services, appSettingsSection);
        }

        private static AppSettings ConfigureAppSettings(IServiceCollection services)
        {
            // pobranie appsettings z konfiguracji i zmapowanie na klase AppSettings 
            //Microsoft.Extensions.Options.ConfigurationExtensions
            //var appSettings = _configuration.GetSection(nameof(AppSettings));
            //var appSettingsSection = appSettings.Get<AppSettings>();
            // services.Configure<AppSettings>(appSettings);

            string workingDirectory = AppContext.BaseDirectory;
            string projectDir = Directory.GetParent(workingDirectory).Parent.Parent.Parent.Parent.Parent.FullName;

            string s = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
              .AddUserSecrets<MauiApp>()
              .SetBasePath(projectDir)
              .AddJsonFile("appsettings.json");
            //.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true);
            IConfiguration _configuration = builder.Build();

            var appSettings = _configuration.GetSection(nameof(AppSettings));
            var appSettingsSection = appSettings.Get<AppSettings>();

            //Debug.WriteLine("" + appSettingsSection.LibraryEndpoints.Base_url);
            //foreach (var setting in _configuration.GetSection("AppSettings").GetChildren())
            //{
            //    Debug.WriteLine($"{setting.Key}: {setting.Value}");
            //}


            services.AddSingleton(appSettingsSection);
            //services.Configure<AppSettings>(appSettings);

            //var appSettingsSection = new AppSettings()
            //{
            //    //BaseAPIUrl = "http://localhost:5093",
            //    //BaseAPIUrl = "https://alxshopapi.azurewebsites.net",

            //    BaseAPIUrl = "https://localhost:7230",
            //    LibraryEndpoints = new LibraryEndpoints()
            //    {
            //        Base_url = "api/Book/",
            //        GetBooksEndpoint= "api/Book",
            //        GetBookEndpoint= "api/Book/{0}",
            //        UpdateBookEndpoint= "api/Book/{0}",
            //        DeleteBookEndpoint= "api/Book/{0}",
            //        AddBookEndpoint= "api/Book",
            //        SearchBooksEndpoint= "api/Book/search"
            //    },
            //    //BaseBookEndpoint = new BaseBookEndpoint()
            //    //{
            //    //   Base_url = "api/Book/",
            //    //    GetAllBooksEndpoint = "",
            //    //},
            //};
            //services.AddSingleton(appSettingsSection);

            return appSettingsSection;
        }

        private static void ConfigureAppServices(IServiceCollection services, AppSettings appSettings)
        {
            services.AddSingleton<IConnectivity>(Connectivity.Current);
            services.AddSingleton<IGeolocation>(Geolocation.Default);
            services.AddSingleton<IMap>(Map.Default);

            // konfiguracja serwisów 
            services.AddSingleton<ILibraryService, LibraryService>();
            services.AddSingleton<IMessageDialogService, MauiMessageDialogService>();

            //services.AddSingleton<IAuthService, AuthService>();

            services.AddSingleton<ITranslationsManager, TranslationsManager>();
            services.AddSingleton<ITranslationsManager>(translationsManager =>
            {
                return new TranslationsManager();
            });

        }

        private static void ConfigureViewModels(IServiceCollection services)
        {

            // konfiguracja viewModeli 


            services.AddSingleton<MainViewModel>();
            services.AddTransient<BookDetailsViewModel>();
            services.AddSingleton<LoginViewModel>();
        }

        private static void ConfigureViews(IServiceCollection services)
        {
            // konfiguracja okienek 
            services.AddSingleton<MainPage>();
            services.AddTransient<BookDetailsView>();
            services.AddTransient<LoginView>();
        }

        private static void ConfigureHttpClients(IServiceCollection services, AppSettings appSettingsSection)
        {
            var uriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
            {
                //Path = appSettingsSection.LibraryEndpoints.Base_url,
            };
            //Microsoft.Extensions.Http
            services.AddHttpClient<ILibraryService, LibraryService>(client => client.BaseAddress = uriBuilder.Uri);
            services.AddHttpClient<IAuthService, AuthService>(client => client.BaseAddress = uriBuilder.Uri);
            services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
        }
    }
}