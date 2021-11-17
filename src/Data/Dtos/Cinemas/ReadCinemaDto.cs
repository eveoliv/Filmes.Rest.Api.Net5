using Filmes.Rest.Api.Net5.Models;
using System.ComponentModel.DataAnnotations;

namespace Filmes.Rest.Api.Net5.Data.Dtos.Cinemas
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
       
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public Gerente Gerente { get; set; }
    }
}
