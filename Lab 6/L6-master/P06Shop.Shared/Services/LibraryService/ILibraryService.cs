using P06Shop.Shared;
using P06Shop.Shared.Library;

namespace P06Shop.Shared.Services.LibraryService
{
    public interface ILibraryService
    {
        Task<ServiceResponse<List<Book>>> GetBooksAsync();

        Task<ServiceResponse<Book>> UpdateBookAsync(Book product);

        Task<ServiceResponse<bool>> DeleteBookAsync(int id);

        Task<ServiceResponse<Book>> CreateBookAsync(Book product);

        Task<ServiceResponse<Book>> GetBookByIdAsync(int id);
        Task<ServiceResponse<List<Book>>> SearchBooksAsync(string text, int page, int pageSize);
    }
}
