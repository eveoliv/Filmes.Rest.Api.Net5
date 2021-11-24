using System;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Filmes.Usuarios.Api.Net5.Services
{
    public class LogoutService
    {
        private readonly SignInManager<IdentityUser<int>> signInManager;

        public LogoutService(SignInManager<IdentityUser<int>> signInManager)
        {
            this.signInManager = signInManager;
        }

        public Result DeslogaUsuario()
        {
            var resultado = signInManager.SignOutAsync();
            if (resultado.IsCompletedSuccessfully)
                return Result.Ok();

            return Result.Fail("Logout falhou.");
        }
    }
}
