using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using P12MAUI.Client;
using P12MAUI.Client.ViewModels;
using P06Library.Shared.Configuration;
using P06Library.Shared.MessageBox;
using P06Library.Shared.Services.AuthService;
using P06Library.Shared.Services.LibraryService;
using P12MAUI.Client.MessageBox;
using System.Diagnostics;
using P06Library.Shared.Languages;
using Microsoft.AspNetCore.Components.Authorization;
using P12MAUI.Client.Services.CustomAuthStateProvider;
using Microsoft.Maui.Handlers;

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
            //builder.Logging.AddDebug();
#endif


            /*
            builder.ConfigureMauiHandlers((handlers) =>
            {
                handlers.AddHandler<WebView, WebViewHandler>();
            });
            */

            ConfigureServices(builder.Services);
            return builder.Build();
        }


        private static void ConfigureServices(IServiceCollection services)
        {
            Debug.WriteLine(">>> Configure Services");
            var appSettingsSection = ConfigureAppSettings(services);
            ConfigureAppServices(services, appSettingsSection);
            ConfigureViewModels(services);
            ConfigureViews(services);
            ConfigureHttpClients(services, appSettingsSection);
        }

        private static AppSettings ConfigureAppSettings(IServiceCollection services)
        {
            // Działa jedynie na Windowsie
            /*
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

            services.AddSingleton(appSettingsSection);
            */

            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            string baseUrl = "https://handy-freedom-408622.nw.r.appspot.com";
            if (env == "Development" && DeviceInfo.Current.Platform == DevicePlatform.WinUI)
            {
                baseUrl = "https://localhost:7230";
            }

            Debug.WriteLine(">>> Current configuration: '" + env + "'");
            Debug.WriteLine($">>>>>> API BaseURL: {baseUrl}");

            var appSettingsSection = new AppSettings()
            {
                BaseAPIUrl = baseUrl,
                FacebookLoginEndpoint = "api/Auth/login-by-facebook",
                LibraryEndpoints = new LibraryEndpoints()
                {
                    Base_url = "api/Book/",
                    GetBooksEndpoint= "api/Book",
                    GetBookEndpoint= "api/Book/{0}",
                    UpdateBookEndpoint= "api/Book/{0}",
                    DeleteBookEndpoint= "api/Book/{0}",
                    AddBookEndpoint= "api/Book",
                    SearchBooksEndpoint= "api/Book/search",
                    GetBooksCountEndpoint= "api/Book/count",
                    GetAllBooksCountEndpoint = "api/Book/count-all"
                },
            };
            services.AddSingleton(appSettingsSection);
            Debug.WriteLine("> Added App Settings");


            //Debug.WriteLine("" + appSettingsSection.LibraryEndpoints.Base_url);
            //foreach (var setting in _configuration.GetSection("AppSettings").GetChildren())
            //{
            //    Debug.WriteLine($"{setting.Key}: {setting.Value}");
            //}


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

            Debug.WriteLine("> Added App Services");
        }

        private static void ConfigureViewModels(IServiceCollection services)
        {

            // konfiguracja viewModeli 


            services.AddSingleton<MainViewModel>();
            services.AddTransient<BookDetailsViewModel>();
            services.AddSingleton<LoginViewModel>();

            Debug.WriteLine("> Added App View Models");
        }

        private static void ConfigureViews(IServiceCollection services)
        {
            // konfiguracja okienek 
            services.AddSingleton<MainPage>();
            services.AddTransient<BookDetailsView>();
            services.AddSingleton<LoginView>();

            Debug.WriteLine("> Added App Views");
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


            Debug.WriteLine("> Added App Http Clients");
        }
    }
}