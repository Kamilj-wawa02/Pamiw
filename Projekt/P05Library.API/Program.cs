using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using P05Library.API.Models;
using P05Library.API.Services.AuthService;
using P05Library.API.Services.LibraryService;
using P06Library.Shared.Services.LibraryService;
using System.Diagnostics;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Microsoft.EntityFrameworkCore.SqlServer
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ILibraryService, P05Library.API.Services.LibraryService.LibraryService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IFacebookAPIService, FacebookAPIService>();

// addScoped - obiekt jest tworzony za kazdym razem dla nowego zapytania http
// jedno zaptranie tworzy jeden obiekt 

// addTransinet obiekt jest tworzony za kazdym razem kiedy odwolujmey sie do konstuktora 
// nawet wielokrotnie w cyklu jedengo zaptrania 

//addsingleton - nowa instancja klasy tworzona jest tylko 1 na caly cykl trwania naszej aplikacji 


// IHttpClientFactory do obs³ugi ¿¹dañ do Facebooka
builder.Services.AddHttpClient();


// +
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:7070")
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials();
        });
});

// Dodanie autentykacji za pomoc¹ JWT
string token = builder.Configuration.GetSection("AppSettings:Token").Value;
Debug.WriteLine("============================ SECRET TOKEN: '" + token + "' ============================");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        // options.Authority = "https://localhost:5001";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //ValidIssuer
            //ValidAudience
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token)),
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
        };
    });

builder.Services.AddAuthorization();

/*
// Autentykacja poprzez Google:
string clientId = builder.Configuration.GetSection("AppSettings:FacebookClientID").Value;
string clientSecret = builder.Configuration.GetSection("AppSettings:FacebookClientSecret").Value;
builder.Services.AddAuthentication()
    .AddFacebook(options =>
    {
        options.ClientId = clientId;
        options.ClientSecret = clientSecret;
    });
*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin"); // +

app.UseHttpsRedirection();

app.UseAuthentication(); // ++
app.UseAuthorization(); //

app.MapControllers();

app.Run();
