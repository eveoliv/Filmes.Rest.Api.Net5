using AutoMapper;
using System.Linq;
using FluentResults;
using Filmes.Rest.Api.Net5.Data;
using Filmes.Rest.Api.Net5.Models;
using Filmes.Rest.Api.Net5.Data.Dtos.Enderecos;

namespace Filmes.Rest.Api.Net5.Services
{
    public class EnderecoService
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto dto)
        {
            var endereco = mapper.Map<Endereco>(dto);
            context.Enderecos.Add(endereco);
            context.SaveChanges();
            return mapper.Map<ReadEnderecoDto>(endereco);
        }

        public ReadEnderecoDto RecuperaEnderecoPorId(int id)
        {
            var endereco = context.Enderecos.FirstOrDefault(f => f.Id == id);
            if (endereco != null)
                return mapper.Map<ReadEnderecoDto>(endereco);

            return null;
        }

        public Result AtualizarEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            var endereco = context.Enderecos.FirstOrDefault(f => f.Id == id);

            if (endereco == null)
                return Result.Fail("Endereco não encontrado");

            mapper.Map(enderecoDto, endereco);
            context.SaveChanges();

            return Result.Ok();
        }

        public Result DeletaEndereco(int id)
        {
            var endereco = context.Enderecos.FirstOrDefault(f => f.Id == id);
            if (endereco == null)
                return Result.Fail("Endereco não encontrado");

            context.Remove(endereco);
            context.SaveChanges();

            return Result.Ok();
        }
    }
}
