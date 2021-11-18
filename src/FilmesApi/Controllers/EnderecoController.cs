using Microsoft.AspNetCore.Mvc;
using Filmes.Rest.Api.Net5.Services;
using Filmes.Rest.Api.Net5.Data.Dtos.Enderecos;

namespace Filmes.Rest.Api.Net5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService service;

        public EnderecoController(EnderecoService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            var endereco = service.AdicionaEndereco(enderecoDto);
            return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId(int id)
        {
            var endereco = service.RecuperaEnderecoPorId(id);
            if (endereco != null)
                return Ok(endereco);

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            var resultado = service.AtualizarEndereco(id, enderecoDto);
            if (resultado.IsFailed)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            var endereco = service.DeletaEndereco(id);
            if (endereco == null)
                return NotFound();

            return NoContent();
        }
    }
}
