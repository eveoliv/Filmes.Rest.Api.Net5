using Filmes.Usuarios.Api.Net5.Data.Dtos.Requests;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace Filmes.Usuarios.Api.Net5.Services
{
    public class LoginService
    {
        private readonly SignInManager<IdentityUser<int>> signInManager;
        private readonly TokenService tokenService;
        
        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var login = signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);

            if (login.Result.Succeeded)
            {
                var identityUser = signInManager.UserManager.Users.FirstOrDefault(usr => usr.NormalizedUserName == request.UserName.ToUpper());
                var token = tokenService.CreateToken(identityUser);                                
                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Login falhou.");
        }
    }
}
