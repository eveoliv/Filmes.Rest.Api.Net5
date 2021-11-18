using Filmes.Rest.Api.Net5.Models;
using System.Collections.Generic;

namespace Filmes.Rest.Api.Net5.Data.Dtos.Gerentes
{
    public class ReadGerenteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public object Cinemas { get; set; }
    }
}
