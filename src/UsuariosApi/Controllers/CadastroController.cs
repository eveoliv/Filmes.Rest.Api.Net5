using Microsoft.AspNetCore.Mvc;
using Filmes.Usuarios.Api.Net5.Services;
using Filmes.Usuarios.Api.Net5.Data.Dtos.Usuarios;
using Filmes.Usuarios.Api.Net5.Data.Dtos.Requests;

namespace Filmes.Usuarios.Api.Net5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private readonly CadastroService service;

        public CadastroController(CadastroService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto usuarioDto)
        {
            var resultado = service.CadastraUsuario(usuarioDto);
            if (resultado.IsFailed)
                return StatusCode(500);

            return Ok(resultado.Reasons);
        }

        [HttpPost("/ativa")]
        public IActionResult AtivaContaUsuario([FromQuery]AtivaContaRequest request)
        {
            var resultado = service.AtivaContaUsuario(request);
            if (resultado.IsFailed)
                return StatusCode(500);

            return Ok(resultado.Reasons);
        }

    }
}
