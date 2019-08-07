using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Models;
using Biblioteca.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Biblioteca.Helper;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        public AuthController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]CredentialsViewModel credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(credentials.UserName) || string.IsNullOrEmpty(credentials.Password))
                return BadRequest();

            var userToVerify = await _userManager.FindByNameAsync(credentials.UserName);                

            if (userToVerify == null) {
                userToVerify = await _userManager.FindByEmailAsync(credentials.UserName);

                if (userToVerify == null)
                    return BadRequest();
            }

            if (await _userManager.CheckPasswordAsync(userToVerify, credentials.Password)) {
                var util = new Utils();
                return Ok(util.GenerateToken(credentials));
            
            } else return Unauthorized();
        }
    }
}
