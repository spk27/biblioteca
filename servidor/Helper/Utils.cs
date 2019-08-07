using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Biblioteca.Models;
using Biblioteca.Models.ViewModels;
using Microsoft.IdentityModel.Tokens;

namespace Biblioteca.Helper
{
    public class Utils {
      public string GenerateToken(CredentialsViewModel credentials) {
        List<Claim> claims = new List<Claim>();
        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, credentials.UserName));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

        var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"));

        var token = new JwtSecurityToken(
            issuer: "biblioteca-bluesoft",
            audience: "http://localhost:5000/",
            expires: DateTime.UtcNow.AddDays(1),
            claims: claims,
            signingCredentials: new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
      }
    }
}
