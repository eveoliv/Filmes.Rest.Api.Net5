using System.ComponentModel.DataAnnotations;

namespace Filmes.Usuarios.Api.Net5.Data.Dtos.Requests
{
    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
