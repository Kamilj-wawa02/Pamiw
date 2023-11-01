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
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using P06Shop.Shared.Shop;

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

        public async Task<ServiceResponse<Book>> CreateBookAsync(Book product)
        {
            var url = _appSettings.BaseAPIUrl + "/" + _appSettings.LibraryEndpoints.GetBooksEndpoint;
            Debug.WriteLine("ServiceMethod -> CreateBookAsync : " + url);
            var response = await _httpClient.PostAsJsonAsync(url, product);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Book>>();
            Debug.WriteLine("Result: " + result);
            return result;
        }

        public async Task<ServiceResponse<bool>> DeleteBookAsync(int id)
        {   
            // jesli uzyjemy / na poczatku to wtedy sciezka trakktowana jest od root czyli pomija czesc środkową adresu 
            // zazwyczaj unikamy stosowania / na poczatku 
            var url = _appSettings.BaseAPIUrl + "/" + String.Format(_appSettings.LibraryEndpoints.DeleteBookEndpoint, id);
            Debug.WriteLine("ServiceMethod -> DeleteBookAsync : " + url);
            var response = await _httpClient.DeleteAsync(url);
            Debug.WriteLine("Response: " + response);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            Debug.WriteLine("Result: " + result);
            return result;
        }


        //// skopiowane z postmana 
        //public async Task<ServiceResponse<List<Book>>> GetBooksAsync()
        //{
        //    //var client = new HttpClient();   
        //    var request = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseBookEndpoint.GetAllBooksEndpoint);
        //    var response = await _httpClient.SendAsync(request);
        //    response.EnsureSuccessStatusCode();        
        //    var json = await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<ServiceResponse<List<Book>>>(json);
        //    return result;
        //}


        // alternatywny sposób pobierania danych 
        public async Task<ServiceResponse<List<Book>>> GetBooksAsync()
        {
            var url = _appSettings.BaseAPIUrl + "/" + _appSettings.LibraryEndpoints.GetBooksEndpoint;
            Debug.WriteLine("ServiceMethod -> GetBooksAsync : " + url);
            var response = await _httpClient.GetAsync(url);
            Debug.WriteLine("Response: " + response);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<Book>>>(json);
            Debug.WriteLine("Result: " + result);
            return result;
        }

        // wersja 1 
        //public async Task<ServiceResponse<Book>> UpdateBookAsync(Book product)
        //{
        //    var response = await _httpClient.PutAsJsonAsync(_appSettings.BaseBookEndpoint.GetAllBooksEndpoint, product);
        //    var json = await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<ServiceResponse<Book>>(json);
        //    return result;
        //}

        // wersja 2 
        public async Task<ServiceResponse<Book>> UpdateBookAsync(Book book)
        {
            var url = _appSettings.BaseAPIUrl + "/" + _appSettings.LibraryEndpoints.GetBooksEndpoint;
            Debug.WriteLine("ServiceMethod -> UpdateBookAsync : " + url);

            var content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");

            Debug.WriteLine("Updating book::: " + await content.ReadAsStringAsync());


            var response = await _httpClient.PutAsync(url, content);
            Debug.WriteLine("Response: " + response);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Book>>();
            Debug.WriteLine("Success: " + result.Success + ", Result: " + result);

            return result;
        }
    }
}
