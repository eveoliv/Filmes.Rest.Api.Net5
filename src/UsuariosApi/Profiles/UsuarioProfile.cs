using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Filmes.Usuarios.Api.Net5.Models;
using Filmes.Usuarios.Api.Net5.Data.Dtos.Usuarios;

namespace Filmes.Usuarios.Api.Net5.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
        }

    }
}
