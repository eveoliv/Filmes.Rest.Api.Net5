using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace Filmes.Usuarios.Api.Net5.Models
{
    public class Mensagem
    {
        public List<MailboxAddress> Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }

        public Mensagem(IEnumerable<string> destinatario, string assunto, int usuarioId, string codigo)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(d => new MailboxAddress(d)));
            Assunto = assunto;
            Conteudo = $"http://localhost:23617/ativa?UsuarioId{usuarioId}&CodigoAtivacao={codigo}";
        }


      
    }
}
