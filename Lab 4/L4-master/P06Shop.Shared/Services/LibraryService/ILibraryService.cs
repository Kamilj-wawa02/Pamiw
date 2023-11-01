using P06Shop.Shared.Library;

namespace P06Shop.Shared.Services.LibraryService
{
    public interface ILibraryService
    {
        Task<ServiceResponse<List<Book>>> GetBooksAsync();
        
        Task<ServiceResponse<Book>> UpdateBookAsync(Book book);
        
        Task<ServiceResponse<bool>> DeleteBookAsync(int id);

        Task<ServiceResponse<Book>> CreateBookAsync(Book book);
    }
}
