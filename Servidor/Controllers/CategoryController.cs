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
    public class CategoryController : ControllerBase
    {
        private readonly LibraryContext _context;
        private readonly ILogger _logger;
        public CategoryController(LibraryContext context, ILogger<CategoryController> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        [HttpGet]
        public IActionResult GetCategories() => new OkObjectResult(_context.Category.ToList());

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category category) {
            if (!ModelState.IsValid) {
                return new BadRequestObjectResult(ModelState.FirstOrDefault());
            }
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
            _logger.LogInformation(2000, "Categoria creada");
            return new OkResult();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category) {
            _context.Category.Update(category);
            await _context.SaveChangesAsync();
            _logger.LogInformation(2000, "Categoria actualizada");
            return new OkResult();
        }
        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteCategory(int ID) {
            var cat = _context.Category.Where(c => c.CategoryId == ID).FirstOrDefault();
            _context.Category.Remove(cat);
            await _context.SaveChangesAsync();
            _logger.LogInformation(2000, "Categoria borrada");
            return new OkResult();
        }
    }
}
