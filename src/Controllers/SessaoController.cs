using AutoMapper;
using Filmes.Rest.Api.Net5.Data;
using Filmes.Rest.Api.Net5.Data.Dtos.Sessoes;
using Filmes.Rest.Api.Net5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Filmes.Rest.Api.Net5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : Controller
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public SessaoController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            var sessao = mapper.Map<Sessao>(sessaoDto);
            context.Sessoes.Add(sessao);
            context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessaorId), new { sessao.Id }, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaorId(int id)
        {
            var sessao = context.Sessoes.FirstOrDefault(f => f.Id == id);
            if (sessao != null)
                return Ok(mapper.Map<ReadSessaoDto>(sessao));

            return NotFound();
        }
    }
}
