namespace Filmes.Usuarios.Api.Net5.Models
{
    public class Token
    {
        public Token(string value)
        {
            Value = value;
        }

        public string Value { get; }

    }
}
