using P05Library.API;
using P05Library.API.Library;

namespace P05Library.API.Services.LibraryService
{
    public interface ILibraryService
    {

        void SetAuthToken(string authToken);

        Task<ServiceResponse<List<Book>>> GetBooksAsync();

        Task<ServiceResponse<Book>> UpdateBookAsync(Book product);

        Task<ServiceResponse<bool>> DeleteBookAsync(int id);

        Task<ServiceResponse<Book>> CreateBookAsync(Book product);

        Task<ServiceResponse<Book>> GetBookByIdAsync(int id);
        Task<ServiceResponse<List<Book>>> SearchBooksAsync(string text, int page, int pageSize);

        Task<ServiceResponse<int>> GetBooksCountAsync(string searchText);

        int GetMaxPage(int elementsPerPage, int elementsCount);

    }
}
