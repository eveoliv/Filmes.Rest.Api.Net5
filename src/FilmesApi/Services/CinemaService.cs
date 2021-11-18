using AutoMapper;
using System.Linq;
using FluentResults;
using Filmes.Rest.Api.Net5.Data;
using System.Collections.Generic;
using Filmes.Rest.Api.Net5.Models;
using Filmes.Rest.Api.Net5.Data.Dtos.Cinemas;

namespace Filmes.Rest.Api.Net5.Services
{
    public class CinemaService
    {
        private readonly IMapper mapper;
        private readonly AppDbContext context;

        public CinemaService(AppDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }
   
        public ReadCinemaDto AdicionaCinema(CreateCinemaDto dto)
        {
            var cinema = mapper.Map<Cinema>(dto);
            context.Cinemas.Add(cinema);
            context.SaveChanges();

            return mapper.Map<ReadCinemaDto>(cinema);
        }

        public List<ReadCinemaDto> RecuperarCinemas(string nomeDoFilme)
        {
            var cinemas = context.Cinemas.ToList();
            if (cinemas == null)
                return null;

            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                var qry = from cinema in cinemas
                          where cinema.Sessoes.Any(sessao =>
                          sessao.Filme.Titulo == nomeDoFilme)
                          select cinema;
                cinemas = qry.ToList();
            }

            return mapper.Map<List<ReadCinemaDto>>(cinemas);
        }

        public ReadCinemaDto RecupaCinemaPorId(int id)
        {
            var cinema = BuscaPorId(id);
            if (cinema != null)
                return mapper.Map<ReadCinemaDto>(cinema);

            return null;
        }

        public Result AtualizaCinema(int id, UpdateCinemaDto dto)
        {
            var cinema = BuscaPorId(id);
            if (cinema == null)
                return Result.Fail("Cinema não encontrado");

            mapper.Map(dto, cinema);
            context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaCinema(int id)
        {
            var cinema = BuscaPorId(id);
            if (cinema == null)
                return Result.Fail("Filme não encontrado");

            context.Remove(cinema);
            context.SaveChanges();
            return Result.Ok();
        }

        private Cinema BuscaPorId(int id)
        {
            return context.Cinemas.FirstOrDefault(f => f.Id == id);
        }
    }
}
