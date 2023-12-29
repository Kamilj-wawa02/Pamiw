using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using P06Library.Shared.Configuration;
using P06Library.Shared.Languages;
using P06Library.Shared.Services.AuthService;
using P06Library.Shared.Services.LibraryService;
using P11BlazorWebAssembly.Client;
using P11BlazorWebAssembly.Client.Services.CustomAuthStateProvider;
using P11BlazorWebAssembly.Client.Shared;
using System.Diagnostics;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var appSettings = builder.Configuration.GetSection(nameof(AppSettings));
var appSettingsSection = appSettings.Get<AppSettings>();

//appSettingsSection.BaseAPIUrl = "https://handy-freedom-408622.nw.r.appspot.com";

var uriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
{
    //Path = appSettingsSection.LibraryEndpoints.Base_url,
};
//Microsoft.Extensions.Http

//builder.Services.Configure<AppSettings>(appSettings);
//builder.Services.AddSingleton<IOptions<AppSettings>>(new OptionsWrapper<AppSettings>(appSettingsSection));


builder.Services.AddSingleton(appSettingsSection);
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddSingleton<ITranslationsManager>(provider =>
{
    //var hostingEnvironment = provider.GetRequiredService<IWebHostEnvironment>();
    //string projectDir = hostingEnvironment.WebRootPath;
    return new TranslationsManager(); //projectDir + "\\Translations");
});

var jsRuntime = builder.Services.BuildServiceProvider().GetRequiredService<IJSRuntime>();
MainLayout.Language = await jsRuntime.InvokeAsync<string>("localStorage.getItem", "language");
MainLayout.Language = MainLayout.Language == null ? "english" : MainLayout.Language.Trim().Replace("\"", "");


// autorization
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
//builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddHttpClient<IAuthService, AuthService>(client => client.BaseAddress = uriBuilder.Uri);
builder.Services.AddHttpClient<ILibraryService, LibraryService>(client => client.BaseAddress = uriBuilder.Uri);

await builder.Build().RunAsync();
