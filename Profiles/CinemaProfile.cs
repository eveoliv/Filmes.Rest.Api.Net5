using AutoMapper;
using Filmes.Rest.Api.Net5.Models;
using Filmes.Rest.Api.Net5.Data.Dtos.Cinema;

namespace Filmes.Rest.Api.Net5.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<Cinema, ReadCinemaDto>();
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
