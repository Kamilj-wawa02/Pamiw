using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P06Shop.Shared;
using P06Shop.Shared.Services.LibraryService;
using P06Shop.Shared.Library;

namespace P05Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ILibraryService _libraryService;
        private readonly ILogger<BookController> _logger;
        public BookController(ILibraryService productService, ILogger<BookController> logger)
        {
            _libraryService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBooks()
        {
            _logger.Log(LogLevel.Information, "Invoked GetBooks Method in controller");

            var result = await _libraryService.GetBooksAsync();

            if (result.Success)
                return Ok(result);
            else
                return  StatusCode(500, $"Internal server error {result.Message}");
        }


        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Book>>> UpdateBook([FromBody] Book product)
        {
            
            var result = await _libraryService.UpdateBookAsync(product);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Book>>> CreateBook([FromBody] Book product)
        {
            var result = await _libraryService.CreateBookAsync(product);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        // http:localhost/api/product/delete?id=4
        // http:localhost/api/product/4 dla api REST
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteBook([FromRoute] int id)
        {
            var result = await _libraryService.DeleteBookAsync(id);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }



    }
}
