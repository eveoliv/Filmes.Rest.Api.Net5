using AutoMapper;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Filmes.Rest.Api.Net5.Data;
using Filmes.Rest.Api.Net5.Models;
using Filmes.Rest.Api.Net5.Data.Dtos.Cinema;

namespace Filmes.Rest.Api.Net5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly AppDbContext context;

        public CinemaController(IMapper mapper, AppDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            var cinema = mapper.Map<Cinema>(cinemaDto);
            context.Cinemas.Add(cinema);
            context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { cinema.Id }, cinema);
        }

        [HttpGet]
        public IActionResult RecuperarCinemas()
        {
            return Ok(context.Cinemas);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
            var cinema = context.Cinemas.FirstOrDefault(f => f.Id == id);
            if (cinema != null)
                return Ok(mapper.Map<ReadCinemaDto>(cinema));

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            var cinema = context.Cinemas.FirstOrDefault(f => f.Id == id);

            if (cinema == null)
                return NotFound();

            mapper.Map(cinemaDto, cinema);
            context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            var cinema = context.Cinemas.FirstOrDefault(f => f.Id == id);
            if (cinema == null)
                return NotFound();

            context.Remove(cinema);
            context.SaveChanges();

            return NoContent();
        }
    }
}
