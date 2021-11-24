using Microsoft.AspNetCore.Mvc;
using Filmes.Usuarios.Api.Net5.Services;
using Filmes.Usuarios.Api.Net5.Data.Dtos.Requests;

namespace Filmes.Usuarios.Api.Net5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService service;

        public LoginController(LoginService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult LogaUsuario(LoginRequest loginRequest)
        {
            var resultado = service.LogaUsuario(loginRequest);
            if (resultado.IsFailed)
                return Unauthorized(resultado.Errors);


            return Ok(resultado.Reasons);
        }
    }
}
