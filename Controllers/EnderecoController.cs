using AutoMapper;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Filmes.Rest.Api.Net5.Data;
using Filmes.Rest.Api.Net5.Models;
using Filmes.Rest.Api.Net5.Data.Dtos.Endereco;

namespace Filmes.Rest.Api.Net5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly Mapper mapper;

        public EnderecoController(AppDbContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
    
        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = mapper.Map<Endereco>(enderecoDto);
            context.Enderecos.Add(endereco);
            context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = endereco.Id }, endereco);

        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId(int id)
        {
            var endereco = context.Cinemas.FirstOrDefault(f => f.Id == id);
            if (endereco != null)
                return Ok(mapper.Map<ReadEnderecoDto>(endereco));

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            var endereco = context.Enderecos.FirstOrDefault(f => f.Id == id);

            if (endereco == null)
                return NotFound();

            mapper.Map(enderecoDto, endereco);
            context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            var endereco = context.Enderecos.FirstOrDefault(f => f.Id == id);
            if (endereco == null)
                return NotFound();

            context.Remove(endereco);
            context.SaveChanges();

            return NoContent();
        }
    }
}
