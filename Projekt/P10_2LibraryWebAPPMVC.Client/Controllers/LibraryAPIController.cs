using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P06Shop.Shared.Services.LibraryService;
using P06Shop.Shared.Library;
using System.Diagnostics;

namespace P09ShopWebAPPMVC.Client.Controllers
{
    public class LibraryAPIController : Controller
    {
      
        private readonly ILibraryService _libraryService;

        public LibraryAPIController(ILibraryService productService)
        {
            _libraryService = productService;
          
        }

        // GET: Library
        public async Task<IActionResult> Index()
        {
            var books = await _libraryService.GetBooksAsync();
            Debug.WriteLine("books: " + books.Success);
            return books != null ?
                          View(books.Data.AsEnumerable()) :
                          Problem("Entity set 'LibraryContext.Library'  is null.");

            //return products != null ? 
            //              View("~/Views/Library/Index.cshtml", products.Data.AsEnumerable()) :
            //              Problem("Entity set 'ShopContext.Library'  is null.");
        }

        // GET: Library/Details/5
        public async Task<IActionResult> Details(int? id)
        {
         
            if (id == null)
            {
                return NotFound();
            }
            var book = await _libraryService.GetBookByIdAsync((int)id);
            
            if (book.Data == null)
            {
                return NotFound();
            }

            return View(book.Data);
        }

        // GET: Library/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Library/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Description,Barcode,Price,ReleaseDate")] Book book)
        {
             
            if (ModelState.IsValid)
            {
                await _libraryService.CreateBookAsync(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Library/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var book = await _libraryService.GetBookByIdAsync((int)id);
            if (book.Data == null)
            {
                return NotFound();
            }
            return View(book.Data);
        }

        // POST: Library/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Description,Barcode,Price,ReleaseDate")] Book book)
        {

            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var productResult = await _libraryService.UpdateBookAsync(book);
                }
                catch (Exception)
                {
                     return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Library/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var book = await _libraryService.GetBookByIdAsync((int)id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book.Data);
        }

        // POST: Library/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _libraryService.DeleteBookAsync((int)id);
            if (book.Success)
                return RedirectToAction(nameof(Index));
            else
                return NotFound();
          
        }
         
    }
}
