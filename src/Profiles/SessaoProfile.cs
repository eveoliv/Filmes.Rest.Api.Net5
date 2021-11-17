using AutoMapper;
using Filmes.Rest.Api.Net5.Models;
using Filmes.Rest.Api.Net5.Data.Dtos.Sessoes;

namespace Filmes.Rest.Api.Net5.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(dto => dto.HorarioDeInicio, opt => opt
                .MapFrom(dto => dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao * (-1))));

        }
    }
}
