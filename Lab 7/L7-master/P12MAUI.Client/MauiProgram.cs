﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using P04WeatherForecastAPI.Client.ViewModels;
using P06Shop.Shared.Configuration;
using P06Shop.Shared.MessageBox;
using P06Shop.Shared.Services.LibraryService;
using P12MAUI.Client.MessageBox;
using P12MAUI.Client.ViewModels;
using System.Diagnostics;

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

            var builder = new ConfigurationBuilder()
              .AddUserSecrets<MauiApp>()
              .SetBasePath(projectDir)
              .AddJsonFile("appsettings.json");
            IConfiguration _configuration = builder.Build();

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(projectDir)
                .AddJsonFile("appsettings.json")
                .Build();

            var appSettings = _configuration.GetSection(nameof(AppSettings));
            var appSettingsSection = appSettings.Get<AppSettings>();

            //Debug.WriteLine("" + appSettingsSection.LibraryEndpoints.Base_url);
            //foreach (var setting in _configuration.GetSection("AppSettings").GetChildren())
            //{
            //    Debug.WriteLine($"{setting.Key}: {setting.Value}");
            //}



            services.Configure<AppSettings>(appSettings);

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
          
        }

        private static void ConfigureViewModels(IServiceCollection services)
        {

            // konfiguracja viewModeli 
           
        
            services.AddSingleton<BooksViewModel>();
            services.AddTransient<BookDetailsViewModel>();
          
            // services.AddSingleton<BaseViewModel,MainViewModelV3>();
        }

        private static void ConfigureViews(IServiceCollection services)
        {
            // konfiguracja okienek 
            services.AddSingleton<MainPage>();    
            services.AddTransient<BookDetailsView>();
        }

        private static void ConfigureHttpClients(IServiceCollection services, AppSettings appSettingsSection)
        {
            var uriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
            {
                //Path = appSettingsSection.BaseBookEndpoint.Base_url,
                Path = appSettingsSection.LibraryEndpoints.Base_url,
            };
            //Microsoft.Extensions.Http
            services.AddHttpClient<ILibraryService, LibraryService>(client => client.BaseAddress = uriBuilder.Uri);
        }
    }
}