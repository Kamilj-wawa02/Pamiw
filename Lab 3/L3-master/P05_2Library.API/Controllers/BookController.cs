using Microsoft.AspNetCore.Mvc;
using P06Shop.Shared;
using P06Shop.Shared.Services.LibraryService;
using P06Shop.Shared.Library;

namespace P05_Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ILibraryService _libraryService;

        public BookController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBooks()
        {
            //try
            //{
            //    var result = await _productService.GetProductsAsync();
            //    return Ok(result);
            //}
            //catch (Exception ex )
            //{
            //    return StatusCode(500, $"Internal server error {ex.Message}");
            //}  

            // ukrywanie wewnetrznych bledow 

            var result = await _libraryService.GetBooksAsync();

            if (result.Success)
                return Ok(result);
            else
                return  StatusCode(500, $"Internal server error {result.Message}");
        }


    }
}
