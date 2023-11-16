
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using P06Shop.Shared;
using P06Shop.Shared.Configuration;
using P06Shop.Shared.Library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace P06Shop.Shared.Services.LibraryService
{
    public class LibraryService : ILibraryService
    {

        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;
        public LibraryService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings.Value;
        }

        public async Task<ServiceResponse<Book>> CreateBookAsync(Book book)
        {
            //var response = await _httpClient.PostAsJsonAsync(_appSettings.LibraryEndpoints.GetBooksEndpoint, book);
            var url = _appSettings.BaseAPIUrl + "/" + _appSettings.LibraryEndpoints.GetBooksEndpoint;
            var response = await _httpClient.PostAsJsonAsync(url, book);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Book>>();
            return result;
        }

        public async Task<ServiceResponse<bool>> DeleteBookAsync(int id)
        {
            // jesli uzyjemy / na poczatku to wtedy sciezka trakktowana jest od root czyli pomija czesc środkową adresu 
            // zazwyczaj unikamy stosowania / na poczatku 
            //var response = await _httpClient.DeleteAsync($"{id}");
            var url = _appSettings.BaseAPIUrl + "/" + String.Format(_appSettings.LibraryEndpoints.DeleteBookEndpoint, id);
            var response = await _httpClient.DeleteAsync(url);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            return result;
        }




        //// skopiowane z postmana 
        //public async Task<ServiceResponse<List<Book>>> GetBooksAsync()
        //{
        //    //var client = new HttpClient();   
        //    var request = new HttpRequestMessage(HttpMethod.Get, _appSettings.LibraryEndpoints.GetBooksEndpoint);
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
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    return new ServiceResponse<List<Book>>
                    {
                        Success = false,
                        Message = "HTTP request failed"
                    };

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ServiceResponse<List<Book>>>(json)
                    ?? new ServiceResponse<List<Book>> { Success = false, Message = "Deserialization failed" };

                result.Success = result.Success && result.Data != null;

                return result;
            }
            catch (JsonException)
            {
                return new ServiceResponse<List<Book>>
                {
                    Success = false,
                    Message = "Cannot deserialize data"
                };
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Book>>
                {
                    Success = false,
                    Message = "Network error"
                };
            }
        }

        public async Task<ServiceResponse<Book>> GetBookByIdAsync(int id)
        {
            var url = _appSettings.BaseAPIUrl + "/" + String.Format(_appSettings.LibraryEndpoints.GetBookEndpoint, id);
            var response = await _httpClient.GetAsync(url);
            Debug.WriteLine("GetBooks: " + response.IsSuccessStatusCode);


            

            //var response = await _httpClient.GetAsync(id.ToString());
            if (!response.IsSuccessStatusCode)
                return new ServiceResponse<Book>
                {
                    Success = false,
                    Message = "HTTP request failed"
                };

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<Book>>(json)
                ?? new ServiceResponse<Book> { Success = false, Message = "Deserialization failed" };

            result.Success = result.Success && result.Data != null;

            return result;
        }


        // wersja 1 
        //public async Task<ServiceResponse<Book>> UpdateBookAsync(Book book)
        //{
        //    var response = await _httpClient.PutAsJsonAsync(_appSettings.LibraryEndpoints.GetBooksEndpoint, book);
        //    var json = await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<ServiceResponse<Book>>(json);
        //    return result;
        //}

        // wersja 2 
        public async Task<ServiceResponse<Book>> UpdateBookAsync(Book book)
        {
            //var response = await _httpClient.PutAsJsonAsync(_appSettings.LibraryEndpoints.GetBooksEndpoint, book);
            var url = _appSettings.BaseAPIUrl + "/" + _appSettings.LibraryEndpoints.GetBooksEndpoint;
            var content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, content);

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Book>>();
            return result;
        }

        public async Task<ServiceResponse<List<Book>>> SearchBooksAsync(string text, int page, int pageSize)
        {

            try
            {
                string searchUrl = string.IsNullOrWhiteSpace(text) ? "" : $"/{text}";
                var url = _appSettings.BaseAPIUrl + "/" + _appSettings.LibraryEndpoints.SearchBooksEndpoint + searchUrl + $"/{page}/{pageSize}";
                var response = await _httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    return new ServiceResponse<List<Book>>
                    {
                        Success = false,
                        Message = "HTTP request failed"
                    };

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ServiceResponse<List<Book>>>(json)
                    ?? new ServiceResponse<List<Book>> { Success = false, Message = "Deserialization failed" };

                result.Success = result.Success && result.Data != null;

                return result;
            }
            catch (JsonException)
            {
                return new ServiceResponse<List<Book>>
                {
                    Success = false,
                    Message = "Cannot deserialize data"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new ServiceResponse<List<Book>>
                {
                    Success = false,
                    Message = "Network error"
                };
            }
        }
    }
}
