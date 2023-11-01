using P06Shop.Shared;
using P06Shop.Shared.Services.LibraryService;
using P06Shop.Shared.Library;
using P07Shop.DataSeeder;

namespace P05Shop.API.Services.LibraryService
{
    public class LibraryService : ILibraryService
    {
        public async Task<ServiceResponse<List<Book>>> GetBooksAsync()
        {
            try
            {
                var response = new ServiceResponse<List<Book>>()
                {
                    Data = BookSeeder.GenerateBookData(),
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new  ServiceResponse<List<Book>>()
                {
                    Data = null,
                    Message = "Problem with dataseeder library",
                    Success = false
                };
            }
           
        }
    }
}
