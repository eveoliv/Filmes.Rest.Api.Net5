using System;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Filmes.Usuarios.Api.Net5.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Filmes.Usuarios.Api.Net5.Services
{
    public class TokenService
    {
        public Token CreateToken(IdentityUser<int> user)
        {
            var direitosUser = new Claim[]
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString())
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eyJzdWIiOiJ0ZXN0ZSIsIm5hbWUiOiJ0ZXN0ZSIsImlhdCI6MjAyMX0"));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    claims: direitosUser,
                    signingCredentials: credenciais,
                    expires: DateTime.UtcNow.AddHours(1)
                );

            var tokenSting = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token(tokenSting);
        }
    }
}
