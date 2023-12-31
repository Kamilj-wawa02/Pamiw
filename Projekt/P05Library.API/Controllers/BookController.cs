﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P06Library.Shared;
using P06Library.Shared.Services.LibraryService;
using P06Library.Shared.Library;
using Microsoft.AspNetCore.Authorization;

namespace P05Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ILibraryService _libraryService;
        private readonly ILogger<BookController> _logger;
        public BookController(ILibraryService libraryService, ILogger<BookController> logger)
        {
            _libraryService = libraryService;
            _logger = logger;
        }

        [Authorize] // +
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

        [HttpGet("count-all")]
        public async Task<ActionResult<ServiceResponse<int>>> GetAllBooksCount()
        {
            _logger.Log(LogLevel.Information, "Invoked GetAllBooksCount Method in controller");

            var result = await _libraryService.GetBooksCountAsync("");

            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> GetBooksCount([FromQuery] string searchText = "")
        {
            _logger.Log(LogLevel.Information, "Invoked GetBooksCount Method in controller");

            var result = await _libraryService.GetBooksCountAsync(searchText);

            return Ok(result);
    }


        // http:localhost/api/product/4 dla api REST
        [Authorize] // +
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Book>>> GetBook(int id)
        {
          
            var result = await _libraryService.GetBookByIdAsync(id);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        [Authorize] // +
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Book>>> UpdateBook([FromBody] Book product)
        {
            
            var result = await _libraryService.UpdateBookAsync(product);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        [Authorize] // +
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
        [Authorize] // +
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteBook([FromRoute] int id)
        {
            var result = await _libraryService.DeleteBookAsync(id);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }


        [Authorize]
        [HttpGet("search/{text}/{page}/{pageSize}")]
        [HttpGet("search/{page}/{pageSize}")]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> SearchBooks(string? text = null, int page = 1, int pageSize = 10)
        {
            _logger.Log(LogLevel.Information, "Invoked GetBooks Method in controller");

            var result = await _libraryService.SearchBooksAsync(text, page, pageSize);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }


    }
}
