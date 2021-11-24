using AutoMapper;
using System.Linq;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Filmes.Usuarios.Api.Net5.Models;
using Filmes.Usuarios.Api.Net5.Data.Dtos.Usuarios;
using Filmes.Usuarios.Api.Net5.Data.Dtos.Requests;
using System.Web;

namespace Filmes.Usuarios.Api.Net5.Services
{
    public class CadastroService
    {
        private readonly IMapper mapper;
        private readonly EmailService emailService;
        private readonly UserManager<IdentityUser<int>> userManager;      

        public CadastroService(IMapper mapper, EmailService emailService, UserManager<IdentityUser<int>> userManager)
        {
            this.mapper = mapper;
            this.emailService = emailService;
            this.userManager = userManager;
        }

        public Result CadastraUsuario(CreateUsuarioDto usuarioDto)
        {
            var usuario = mapper.Map<Usuario>(usuarioDto);
            var usuarioIdentity = mapper.Map<IdentityUser<int>>(usuario);

            var resultado = userManager.CreateAsync(usuarioIdentity, usuarioDto.Password);
            if (resultado.Result.Succeeded)
            {
                var code = userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                
                emailService.EnviarEmail(new[] { usuarioIdentity.Email }, "Link de ativação.", usuarioIdentity.Id, HttpUtility.UrlEncode(code));
                return Result.Ok().WithSuccess(code);
            }

            return Result.Fail("Falha ao cadastrar Usuario.");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var identityUser = userManager.Users.FirstOrDefault(r => r.Id == request.UsuarioId);
            var identityResult = userManager.ConfirmEmailAsync(identityUser, request.CodigoAtivacao).Result;
            if (identityResult.Succeeded)
                return Result.Ok();

            return Result.Fail("Confirmação falhou.");

        }
    }
}
