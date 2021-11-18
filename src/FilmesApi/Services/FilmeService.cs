using AutoMapper;
using System.Linq;
using FluentResults;
using Filmes.Rest.Api.Net5.Data;
using System.Collections.Generic;
using Filmes.Rest.Api.Net5.Models;
using Filmes.Rest.Api.Net5.Data.Dtos.Filmes;

namespace Filmes.Rest.Api.Net5.Services
{
    public class FilmeService
    {
        private readonly IMapper mapper;
        private readonly AppDbContext context;

        public FilmeService(IMapper mapper, AppDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto)
        {
            var filme = mapper.Map<Filme>(filmeDto);
            context.Filmes.Add(filme);
            context.SaveChanges();

            return mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> RecuperarFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
            {
                filmes = context.Filmes.ToList();
            }
            else
            {
                filmes = context.Filmes.Where(f => f.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }

            if (filmes.Any())
                return mapper.Map<List<ReadFilmeDto>>(filmes);

            return null;
        }

        public ReadFilmeDto RecupaFilmePorId(int id)
        {
            var filme = BuscaPorId(id);
            if (filme != null)
                return mapper.Map<ReadFilmeDto>(filme);

            return null;
        }

        public Result AtualizaFilme(int id, UpdateFilmeDto filmeDto)
        {
            var filme = BuscaPorId(id);
            if (filme == null)            
                return Result.Fail("Filme não encontrado");            

            mapper.Map(filmeDto, filme);
            context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaFilme(int id)
        {
            var filme = BuscaPorId(id);
            if (filme == null)
                return Result.Fail("Filme não encontrado");

            context.Remove(filme);
            context.SaveChanges();
            return Result.Ok();
        }

        private Filme BuscaPorId(int id)
        {
            return context.Filmes.FirstOrDefault(f => f.Id == id);
        }
    }
}
