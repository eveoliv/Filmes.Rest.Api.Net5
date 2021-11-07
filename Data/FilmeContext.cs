using Filmes.Rest.Api.Net5.Models;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Rest.Api.Net5.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base(opt) { }

        public DbSet<Filme> Filmes { get; set; }

    }
}
