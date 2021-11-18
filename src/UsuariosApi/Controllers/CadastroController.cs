using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos.Usuarios;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        [HttpPost]
        public IActionResult CadstraUsuario(CreateUsuarioDto usuarioDto)
        {
            return Ok();
        }
    }
}
