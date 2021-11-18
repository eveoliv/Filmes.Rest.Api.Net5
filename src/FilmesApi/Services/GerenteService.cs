using AutoMapper;
using System.Linq;
using FluentResults;
using Filmes.Rest.Api.Net5.Data;
using Filmes.Rest.Api.Net5.Models;
using Filmes.Rest.Api.Net5.Data.Dtos.Gerentes;

namespace Filmes.Rest.Api.Net5.Services
{
    public class GerenteService
    {
        private readonly IMapper mapper;
        private readonly AppDbContext context;

        public GerenteService(IMapper mapper, AppDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public ReadGerenteDto AdicionaGerente(CreateGerenteDto createGerenteDto)
        {
            var gerente = mapper.Map<Gerente>(createGerenteDto);
            context.Add(gerente);
            context.SaveChanges();

            return mapper.Map<ReadGerenteDto>(gerente);
        }

        public ReadGerenteDto RecuperarGerentePorId(int id)
        {
            var gerente = BuscaPorId(id);
            if (gerente != null)
                return mapper.Map<ReadGerenteDto>(gerente);

            return null;
        }

        public Result AtualizaGerente(int id, UpdateGerenteDto dto)
        {
            var gerente = BuscaPorId(id);
            if (gerente == null)
                return Result.Fail("Gernete não encontrado");

            mapper.Map(dto, gerente);
            context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaGerente(int id)
        {
            var gerente = BuscaPorId(id);
            if (gerente == null)
                return Result.Fail("Gernete não encontrado");

            context.Remove(gerente);
            context.SaveChanges();

            return Result.Ok();
        }

        private Gerente BuscaPorId(int id)
        {
            return context.Gerentes.FirstOrDefault(f => f.Id == id);
        }
    }
}
