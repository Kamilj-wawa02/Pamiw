using Microsoft.AspNetCore.Mvc;
using P06Shop.Shared.Library;

namespace P05Shop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase //https://localhost:7230/api/Library
    {

        private readonly string indexOutOfBoundsLessThan0Message = "Index out of bounds! Must be greater or equal to 0!";
        private readonly string nullTitleAndOrAuthorMessage = "Null Title and/or Author!";

        private readonly ILogger<LibraryController> _logger;

        public LibraryController(ILogger<LibraryController> logger)
        {
            _logger = logger;
        }


        //https://localhost:7230/api/Library
        [HttpPost]
        public IActionResult AddNewBook([FromBody] Book book)
        {
            if (book == null || book.Title == null || book.Author == null)
            {
                return BadRequest(nullTitleAndOrAuthorMessage);
            }
            return
                Ok($"book: Title: {book.Title}, Author : {book.Author}, Id : {book.Id}, Description: {book.Description}");
        }

       
        //https://localhost:7230/api/Library/GetBook/5
        [HttpGet("GetBook/{id}")]
        public IActionResult GetBook([FromRoute] int id)
        {
            if (id < 0)
            {
                return BadRequest(indexOutOfBoundsLessThan0Message);
            }
            return Ok(new Book() { Title = "Some random book title here" });
        }


        //https://localhost:7230/api/Library/UpdateBook/1
        [HttpPut("UpdateBook/{id}")]
        public IActionResult UpdateBook([FromRoute] int id, [FromBody] Book updatedBook)
        {
            if (id < 0)
            {
                return BadRequest(indexOutOfBoundsLessThan0Message);
            }

            if (updatedBook == null || updatedBook.Title == null || updatedBook.Author == null)
            {
                return BadRequest(nullTitleAndOrAuthorMessage);
            }

            return Ok("The book has been updated, current title: " + updatedBook.Title);
        }


        //https://localhost:7230/api/Library/DeleteBook/2
        [HttpDelete("DeleteBook/{id}")]
        public IActionResult DeleteBook([FromRoute] int id)
        {
            if (id < 0)
            {
                return BadRequest(indexOutOfBoundsLessThan0Message);
            }

            return Ok("The book has been deleted!");
        }

    }
}