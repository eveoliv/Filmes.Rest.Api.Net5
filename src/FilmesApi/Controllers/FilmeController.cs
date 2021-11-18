using Microsoft.AspNetCore.Mvc;
using Filmes.Rest.Api.Net5.Services;
using Filmes.Rest.Api.Net5.Data.Dtos.Filmes;

namespace Filmes.Rest.Api.Net5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeService service;

        public FilmeController(FilmeService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
        {
            var filme = service.AdicionaFilme(filmeDto);
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            var filmes = service.RecuperarFilmes(classificacaoEtaria);
            if (filmes != null)
                return Ok(filmes);

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            var filme = service.RecupaFilmePorId(id);
            if (filme != null)
                return Ok(filme);

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            var resultado = service.AtualizaFilme(id, filmeDto);
            if (resultado.IsFailed)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var resultado = service.DeletaFilme(id);
            if (resultado.IsFailed)
                return NotFound();

            return NoContent();        
        }
    }
}
