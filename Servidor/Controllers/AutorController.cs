using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Biblioteca.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly LibraryContext _context;
        private readonly ILogger _logger;

        public AutorController(LibraryContext context, ILogger<AutorController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAutors() => new OkObjectResult(_context.Autor.ToList());

        [HttpPost]
        public async Task<IActionResult> AddAutor([FromBody] Autor autor) {
            if (!ModelState.IsValid) {
                return new BadRequestObjectResult(ModelState.FirstOrDefault());
            }
            _context.Autor.Add(autor);
            await _context.SaveChangesAsync();
            _logger.LogInformation(2000, "Autor creado");
            return new OkResult();
        } 

        [HttpPut]
        public async Task<IActionResult> UpdateAutor([FromBody] Autor autor) {
            _context.Autor.Update(autor);
            await _context.SaveChangesAsync();
            _logger.LogInformation(2000, "Autor editado");
            return new OkResult();
        } 


        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteAutor(int ID) {
            var autor = _context.Autor.Where(c => c.AutorId == ID).FirstOrDefault();
            _context.Autor.Remove(autor);
            await _context.SaveChangesAsync();
            _logger.LogInformation(2000, "Autor eliminado");
            return new OkResult();
        } 
    }
}
