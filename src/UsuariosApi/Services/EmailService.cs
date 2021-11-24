using MimeKit;
using MailKit.Net.Smtp;
using Filmes.Usuarios.Api.Net5.Models;
using Microsoft.Extensions.Configuration;

namespace Filmes.Usuarios.Api.Net5.Services
{
    public class EmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string code)
        {
            var mensagem = new Mensagem(destinatario, assunto, usuarioId, code);

            var msg = CriaCorpoEmail(mensagem);

            Enviar(msg);
        }

        private void Enviar(MimeMessage msg)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(configuration.GetValue<string>("EmailSettings:SmtpServer"), configuration.GetValue<int>("EmailSettings:Port"), true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(configuration.GetValue<string>("EmailSettings:From"), configuration.GetValue<string>("EmailSettings:Password"));
                client.Send(msg);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }

        private MimeMessage CriaCorpoEmail(Mensagem mensagem)
        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress(configuration.GetValue<string>("EmailSettings:From")));
            mailMessage.To.AddRange(mensagem.Destinatario);
            mailMessage.Subject = mensagem.Assunto;
            mailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };

            return mailMessage;
        }
    }
}
