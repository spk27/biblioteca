using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibraryContext _context;
        public BookController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks() => new OkObjectResult(
                _context.Book
                    .Include(a => a.Autor)
                    .Include(c => c.BookCategory)
                        .ThenInclude(cc => cc.Category)
                    .ToList());

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book) {
            if (!ModelState.IsValid) {
                return new BadRequestObjectResult(ModelState.FirstOrDefault());
            }
            if (book.Autor != null && 0 < book.Autor.AutorId) {
                book.Autor = _context.Autor.Where(a => a.AutorId == book.Autor.AutorId).SingleOrDefault();
            }
            // var categorias = book.BookCategory;
            // book.BookCategory = new List<Category>();
            // foreach(var cat in book.BookCategory) {
            //     book.BookCategory.Add(new BookCategory { CategoryId = cat.CategoryId });
            // }
            _context.Book.Add(book);
            
            await _context.SaveChangesAsync();
            return new OkResult();  
        } 

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] Book book) {
            _context.Book.Update(book);
            // foreach(var cat in book.BookCategory) 
            //     _context.Entry(cat).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new OkResult();
        } 
        
        [HttpDelete]
        public async Task<IActionResult> DeleteBook([FromBody] Book book) {
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return new OkResult();
        } 

    }
}
