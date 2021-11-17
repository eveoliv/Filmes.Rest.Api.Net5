using Filmes.Rest.Api.Net5.Models;
using System;

namespace Filmes.Rest.Api.Net5.Data.Dtos.Sessoes
{
    public class ReadSessaoDto
    {
        public int Id { get; set; }
        public Cinema Cinema { get; set; }
        public Filme Filme { get; set; }
        public DateTime HorarioDeInicio { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }

    }
}
