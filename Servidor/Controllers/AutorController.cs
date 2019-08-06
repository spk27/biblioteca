using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly LibraryContext _context;
        public AutorController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAutors() => new OkObjectResult(_context.Autor.ToList());

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Autor autor) {
            if (!ModelState.IsValid) {
                return new BadRequestObjectResult(ModelState.FirstOrDefault());
            }
            _context.Autor.Add(autor);
            await _context.SaveChangesAsync();
            return new OkResult();
        } 

        [HttpPut]
        public async Task<IActionResult> UpdateAutor([FromBody] Autor autor) {
            _context.Autor.Update(autor);
            await _context.SaveChangesAsync();
            return new OkResult();
        } 


        [HttpDelete]
        public async Task<IActionResult> DeleteAutor([FromBody]Autor autor) {
            _context.Autor.Remove(autor);
            await _context.SaveChangesAsync();
            return new OkResult();
        } 
    }
}
