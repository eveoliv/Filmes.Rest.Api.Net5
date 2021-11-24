using System.ComponentModel.DataAnnotations;

namespace Filmes.Usuarios.Api.Net5.Data.Dtos.Usuarios
{
    public class CreateUsuarioDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }

    }
}
