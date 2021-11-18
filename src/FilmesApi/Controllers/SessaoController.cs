using Microsoft.AspNetCore.Mvc;
using Filmes.Rest.Api.Net5.Services;
using Filmes.Rest.Api.Net5.Data.Dtos.Sessoes;

namespace Filmes.Rest.Api.Net5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : Controller
    {
        private readonly SessaoService service;

        public SessaoController(SessaoService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            var sessao = service.AdicionarSessao(sessaoDto);

            return CreatedAtAction(nameof(RecuperaSessaorId), new { sessao.Id }, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaorId(int id)
        {
            var sessao = service.RecuperaSessaorId(id);
            if (sessao != null)
                return Ok(sessao);

            return NotFound();
        }

    }
}
