using Microsoft.AspNetCore.Mvc;
using Filmes.Rest.Api.Net5.Services;
using Filmes.Rest.Api.Net5.Data.Dtos.Cinemas;

namespace Filmes.Rest.Api.Net5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly CinemaService service;

        public CinemaController(CinemaService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            var cinema = service.AdicionaCinema(cinemaDto);
            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { cinema.Id }, cinema);
        }

        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string nomeDoFilme)
        {
            var cinemas = service.RecuperarCinemas(nomeDoFilme);
            if (cinemas != null)
                return Ok(cinemas);

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
            var cinema = service.RecupaCinemaPorId(id);
            if (cinema != null)
                return Ok(cinema);

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            var resultado = service.AtualizaCinema(id, cinemaDto);
            if (resultado.IsFailed)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            var resultado = service.DeletaCinema(id);
            if (resultado.IsFailed)
                return NotFound();

            return NoContent();
        }
    }
}
