using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using P04WeatherForecastAPI.Client.Configuration;
using P06Shop.Shared;
using P06Shop.Shared.Services.LibraryService;
using P06Shop.Shared.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace P04WeatherForecastAPI.Client.Services.LibraryServices
{
    internal class LibraryService : ILibraryService
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;
        public LibraryService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient= httpClient;
            _appSettings= appSettings.Value;
        }


        // alternatywny sposób pobierania danych 
        public async Task<ServiceResponse<List<Book>>> GetBooksAsync()
        {
            var url = _appSettings.BaseAPIUrl + "/" + _appSettings.LibraryEndpoints.GetBooksEndpoint;
            var response = await _httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<Book>>>(json);
            return result;
        }
    }
}
