using System.ComponentModel.DataAnnotations;

namespace Filmes.Usuarios.Api.Net5.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        
        public string UserName { get; set; }
       
        public string Email { get; set; }
        
    }
}
