using AutoMapper;
using Filmes.Rest.Api.Net5.Models;
using Filmes.Rest.Api.Net5.Data.Dtos.Gerentes;
using System.Linq;

namespace Filmes.Rest.Api.Net5.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<UpdateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                .ForMember(gerente => gerente.Cinemas, opt => opt
                .MapFrom(gerente => gerente.Cinemas.Select(
                    s => new { s.Id, s.Nome, s.Endereco, s.EnderecoId })));
        }

    }
}
