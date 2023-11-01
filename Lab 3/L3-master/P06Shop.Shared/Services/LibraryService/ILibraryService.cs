using P06Shop.Shared.Library;

namespace P06Shop.Shared.Services.LibraryService
{
    public interface ILibraryService
    {
        Task<ServiceResponse<List<Book>>> GetBooksAsync();
    }
}
