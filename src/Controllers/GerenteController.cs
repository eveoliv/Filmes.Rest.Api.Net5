using AutoMapper;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Filmes.Rest.Api.Net5.Data;
using Filmes.Rest.Api.Net5.Models;
using Filmes.Rest.Api.Net5.Data.Dtos.Gerentes;

namespace Filmes.Rest.Api.Net5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly AppDbContext context;

        public GerenteController(IMapper mapper, AppDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpPost]
        public IActionResult AdicionaGerente(CreateGerenteDto createGerenteDto)
        {
            var gerente = mapper.Map<Gerente>(createGerenteDto);
            context.Add(gerente);
            context.SaveChanges();

            return CreatedAtAction(nameof(RecuperarGerentePorId), new { gerente.Id }, gerente);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarGerentePorId(int id)
        {
            var gerente = context.Gerentes.FirstOrDefault(f => f.Id == id);
            if (gerente != null)
                return Ok(mapper.Map<ReadGerenteDto>(gerente));

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            var gerente = context.Gerentes.FirstOrDefault(f => f.Id == id);
            if (gerente == null)
                return NotFound();

            context.Remove(gerente);
            context.SaveChanges();

            return NoContent();
        }
    }
}
