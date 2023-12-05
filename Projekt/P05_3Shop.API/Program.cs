using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using P05Shop.API.Models;
using P05Shop.API.Services.AuthService;
using P05Shop.API.Services.LibraryService;
using P06Shop.Shared.Services.LibraryService;
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

builder.Services.AddScoped<ILibraryService, P05Shop.API.Services.LibraryService.LibraryService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// addScoped - obiekt jest tworzony za kazdym razem dla nowego zapytania http
// jedno zaptranie tworzy jeden obiekt 

// addTransinet obiekt jest tworzony za kazdym razem kiedy odwolujmey sie do konstuktora 
// nawet wielokrotnie w cyklu jedengo zaptrania 

//addsingleton - nowa instancja klasy tworzona jest tylko 1 na caly cykl trwania naszej aplikacji 


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

// Dodanie autentykacji za pomoc� JWT
string token = builder.Configuration.GetSection("AppSettings:Token").Value;
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        // options.Authority = "https://localhost:5001";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token)),
            ValidateIssuerSigningKey = true,
        };
    });

// Autentykacja poprzez Google:
string clientId = builder.Configuration.GetSection("AppSettings:GoogleClientID").Value;
string clientSecret = builder.Configuration.GetSection("AppSettings:GoogleClientSecret").Value;
builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = clientId;
        options.ClientSecret = clientSecret;
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin"); // +

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
