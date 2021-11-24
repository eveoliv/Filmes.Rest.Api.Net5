using Microsoft.AspNetCore.Mvc;
using Filmes.Usuarios.Api.Net5.Services;

namespace Filmes.Usuarios.Api.Net5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase
    {
        private readonly LogoutService logoutService;

        public LogoutController(LogoutService logoutService)
        {
            this.logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult DeslogarUsuario()
        {
            var resultado = logoutService.DeslogaUsuario();
            if (resultado.IsFailed)
                return Unauthorized(resultado.Errors);

            return Ok(resultado.Reasons);
        }
    }
}
