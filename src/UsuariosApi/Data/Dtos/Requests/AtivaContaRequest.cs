using System.ComponentModel.DataAnnotations;

namespace Filmes.Usuarios.Api.Net5.Data.Dtos.Requests
{
    public class AtivaContaRequest
    {
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public string CodigoAtivacao { get; set; }
    }
}
