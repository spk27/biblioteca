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
    public class CategoryController : ControllerBase
    {
        private readonly LibraryContext _context;
        public CategoryController(LibraryContext context)
        {
            _context = context;
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
            return new OkResult();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category) {
            _context.Category.Update(category);
            await _context.SaveChangesAsync();
            return new OkResult();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory([FromBody] Category category) {
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return new OkResult();
        }
    }
}
