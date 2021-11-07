using System;
using System.ComponentModel.DataAnnotations;

namespace Filmes.Rest.Api.Net5.Data.Dtos
{
    public class ReadFilmeDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Titulo é obrigatorio.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Campo Diretor é obrigatorio.")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "Tamanho maximo 30 caracteres.")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A duraçao deve ter no entre 1 e 600 segundos.")]
        public int Duracao { get; set; }
        public DateTime HoraDaConsulta { get; set; }
    }
}
