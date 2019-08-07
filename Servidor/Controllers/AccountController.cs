using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Helper;
using Biblioteca.Models;
using Biblioteca.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppUserContext _appDbContext;
        public AccountController(UserManager<AppUser> userManager, AppUserContext appDbContext)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Post([FromBody]CredentialsViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _userManager.FindByEmailAsync(model.UserName) != null) return new BadRequestObjectResult("Este Email ya esta ocupado");

            var userIdentity = new AppUser { UserName = model.UserName, Email = model.UserName };
            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(result);

            await _appDbContext.SaveChangesAsync();
            
            var util = new Utils();
            return Ok(util.GenerateToken(model));
        }

    }
}
