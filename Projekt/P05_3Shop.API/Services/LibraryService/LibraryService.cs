using Microsoft.EntityFrameworkCore;
using P05Shop.API.Models;
using P06Shop.Shared;
using P06Shop.Shared.Services.LibraryService;
using P06Shop.Shared.Library;
using P07Shop.DataSeeder;
using Microsoft.IdentityModel.Tokens;
using static System.Net.Mime.MediaTypeNames;

namespace P05Shop.API.Services.LibraryService
{
    public class LibraryService : ILibraryService
    {
        private readonly DataContext _dataContext;
        public LibraryService(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<ServiceResponse<Book>> CreateBookAsync(Book book)
        {
            try
            {
                _dataContext.Books.Add(book);
                await _dataContext.SaveChangesAsync();
                return new ServiceResponse<Book>() { Data = book, Success = true };
            }
            catch (Exception)
            {
                return new ServiceResponse<Book>()
                {
                    Data = null,
                    Success = false,
                    Message = "Cannot create book"
                };
            }

        }

        public async Task<ServiceResponse<bool>> DeleteBookAsync(int id)
        {
            // sposób 1 (najpierw znajdujemy potem go usuwamy): 
            //var bookToDelete = _dataContext.Books.FirstOrDefault(x => x.Id == id);
            //_dataContext.Books.Remove(bookToDelete);  

            // sposób 2: (uzywamy attach : tylko jedno zapytanie do bazy)
            var book = new Book() { Id = id };
            _dataContext.Books.Attach(book);
            _dataContext.Books.Remove(book);
            await _dataContext.SaveChangesAsync();

            return new ServiceResponse<bool>() { Data = true, Success = true };
        }

        public async Task<ServiceResponse<Book>> GetBookByIdAsync(int id)
        {
            try
            {
                var book = await _dataContext.Books.FindAsync(id);
                var response = new ServiceResponse<Book>()
                {
                    Data = book,
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new ServiceResponse<Book>()
                {
                    Data = null,
                    Message = "Problem with database",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<List<Book>>> GetBooksAsync()
        {
            var books = await _dataContext.Books.ToListAsync();

            try
            {
                var response = new ServiceResponse<List<Book>>()
                {
                    Data = books,
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Book>>()
                {
                    Data = null,
                    Message = "Problem with database",
                    Success = false
                };
            }

        }

        public async Task<ServiceResponse<int>> GetBooksCountAsync(string searchText)
        {
            IQueryable<Book> query = _dataContext.Books;

            try
            {
                if (!string.IsNullOrEmpty(searchText))
                    query = query.Where(x => x.Title.Contains(searchText) || x.Author.Contains(searchText) || x.Description.Contains(searchText));

                var response = new ServiceResponse<int>()
                {
                    Data = (await query.ToListAsync()).Count,
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new ServiceResponse<int>()
                {
                    Data = 0,
                    Message = "Problem with database",
                    Success = false
                };
            }
        }

        public int GetMaxPage(int elementsPerPage, int elementsCount)
        {
            int MaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(elementsCount) / Convert.ToDouble(elementsPerPage)));

            if (MaxPage == 0)
            {
                MaxPage = 1;
            }

            return MaxPage;
        }

        public async Task<ServiceResponse<List<Book>>> SearchBooksAsync(string text, int page, int pageSize)
        {
            IQueryable<Book> query = _dataContext.Books;

            if (!string.IsNullOrEmpty(text))
                query = query.Where(x => x.Title.Contains(text) || x.Author.Contains(text) || x.Description.Contains(text));

            var books = await query
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToListAsync();

            try
            {
                var response = new ServiceResponse<List<Book>>()
                {
                    Data = books,
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Book>>()
                {
                    Data = null,
                    Message = "Problem with database",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<Book>> UpdateBookAsync(Book book)
        {
            try
            {
                var bookToEdit = new Book() { Id = book.Id };
                _dataContext.Books.Attach(bookToEdit);

                bookToEdit.Title = book.Title;
                bookToEdit.Description = book.Description;
                bookToEdit.Price = book.Price;
                bookToEdit.Barcode = book.Barcode;
                bookToEdit.ReleaseDate = book.ReleaseDate;

                await _dataContext.SaveChangesAsync();
                return new ServiceResponse<Book> { Data = bookToEdit, Success = true };
            }
            catch (Exception)
            {
                return new ServiceResponse<Book>
                {
                    Data = null,
                    Success = false,
                    Message = "An error occured while updating book"
                };
            }



        }
    }
}
