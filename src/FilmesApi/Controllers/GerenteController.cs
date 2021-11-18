using Microsoft.AspNetCore.Mvc;
using Filmes.Rest.Api.Net5.Services;
using Filmes.Rest.Api.Net5.Data.Dtos.Gerentes;

namespace Filmes.Rest.Api.Net5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private readonly GerenteService service;

        public GerenteController(GerenteService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult AdicionaGerente(CreateGerenteDto createGerenteDto)
        {
            var gerente = service.AdicionaGerente(createGerenteDto);
            return CreatedAtAction(nameof(RecuperarGerentePorId), new { gerente.Id }, gerente);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarGerentePorId(int id)
        {
            var gerente = service.RecuperarGerentePorId(id);
            if (gerente != null)
                return Ok(gerente);

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            var gerente = service.DeletaGerente(id);
            if (gerente == null)
                return NotFound();           

            return NoContent();
        }
    }
}
