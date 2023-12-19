using P06Library.Shared;
using P06Library.Shared.Library;

namespace P06Library.Shared.Services.LibraryService
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
