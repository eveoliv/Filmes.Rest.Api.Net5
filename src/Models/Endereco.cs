using System.ComponentModel.DataAnnotations;

namespace Filmes.Rest.Api.Net5.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }


    }
}
