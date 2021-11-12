using AutoMapper;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Filmes.Rest.Api.Net5.Data;
using Filmes.Rest.Api.Net5.Models;
using Filmes.Rest.Api.Net5.Data.Dtos;

namespace Filmes.Rest.Api.Net5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly AppDbContext context;

        public FilmeController(IMapper mapper, AppDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
        {
            var filme = mapper.Map<Filme>(filmeDto);
            context.Filmes.Add(filme);
            context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { filme.Id }, filme);            
        }

        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            return Ok(context.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            var filme = context.Filmes.FirstOrDefault(f => f.Id == id);
            if (filme != null)                           
                return Ok(mapper.Map<ReadFilmeDto>(filme));            

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            var filme = context.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme == null)            
                return NotFound();

            mapper.Map(filmeDto, filme);
            context.SaveChanges();
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var filme = context.Filmes.FirstOrDefault(f => f.Id == id);
            if (filme == null)
                return NotFound();

            context.Remove(filme);
            context.SaveChanges();

            return NoContent();
        }
    }
}
