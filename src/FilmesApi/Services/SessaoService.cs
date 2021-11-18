using AutoMapper;
using System.Linq;
using Filmes.Rest.Api.Net5.Data;
using Filmes.Rest.Api.Net5.Models;
using Filmes.Rest.Api.Net5.Data.Dtos.Sessoes;

namespace Filmes.Rest.Api.Net5.Services
{
    public class SessaoService
    {
        private readonly IMapper mapper;
        private readonly AppDbContext context;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ReadSessaoDto AdicionarSessao(CreateSessaoDto sessaoDto)
        {
            var sessao = mapper.Map<Sessao>(sessaoDto);
            context.Sessoes.Add(sessao);
            context.SaveChanges();
            return mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto RecuperaSessaorId(int id)
        {
            var sessao = BuscaPorId(id);
            if (sessao != null)
                return mapper.Map<ReadSessaoDto>(sessao);

            return null;
        }

        private Sessao BuscaPorId(int id)
        {
            return context.Sessoes.FirstOrDefault(f => f.Id == id);
        }
    }
}
