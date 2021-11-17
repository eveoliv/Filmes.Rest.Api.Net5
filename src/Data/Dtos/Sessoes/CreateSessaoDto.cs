using System;

namespace Filmes.Rest.Api.Net5.Data.Dtos.Sessoes
{
    public class CreateSessaoDto 
    {
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
