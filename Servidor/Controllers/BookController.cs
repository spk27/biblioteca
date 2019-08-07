using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;
using Biblioteca.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Biblioteca.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibraryContext _context;
        private readonly ILogger _logger;

        public BookController(LibraryContext context, ILogger<BookController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetBooks() => new OkObjectResult(
                _context.Book
                    .Include(a => a.Autor)
                    .Include(c => c.BookCategory)
                        .ThenInclude(cc => cc.Category)
                    .ToList());

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] ViewBook model) {
            if (!ModelState.IsValid) {
                return new BadRequestObjectResult(ModelState.FirstOrDefault());
            }
            if (model.Book.Autor != null && 0 < model.Book.Autor.AutorId) {
                model.Book.Autor = _context.Autor.Where(a => a.AutorId == model.Book.Autor.AutorId).SingleOrDefault();
            }
            foreach(var cat in model.Categories) {
                model.Book.BookCategory.Add(new BookCategory { CategoryId = cat.CategoryId });
            }
            _context.Book.Add(model.Book);
            
            await _context.SaveChangesAsync();
            _logger.LogInformation(2000, "Libro creado");
            return new OkResult();  
        } 

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] ViewBook model) {
            _context.Book.Update(model.Book);
            var bookCategory = _context.BookCategory.Where(b => b.BookId == model.Book.BookId).ToList();
            foreach(var cat in model.Categories) {
                if(!bookCategory.Where(b => b.CategoryId == cat.CategoryId).Any()) {
                    _context.BookCategory.Add(new BookCategory{ BookId = model.Book.BookId, CategoryId = cat.CategoryId });
                }
            }
            foreach(var cat in bookCategory) {
                if(!model.Categories.Where(b => b.CategoryId == cat.CategoryId).Any()) {
                    _context.BookCategory.Remove(cat);
                }
            }
            // foreach(var cat in book.BookCategory) 
            //     _context.Entry(cat).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            _logger.LogInformation(2000, "Libro actualizado");
            return new OkResult();
        } 
        
        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteBook(int ID) {
            var book = _context.Book.Where(c => c.BookId == ID).FirstOrDefault();
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            _logger.LogInformation(2000, "Libro eliminado");
            return new OkResult();
        } 

    }
}
