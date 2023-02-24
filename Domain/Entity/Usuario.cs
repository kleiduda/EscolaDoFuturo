using Domain.Enums;
using Domain.ValueObject;

namespace Domain.Entity
{
    public class Usuario
    {
        public Usuario(string login, Guid chaveAcesso, string email, Documento cpf, int tipoUsuario)
        {
            Login = login;
            ChaveAcesso = chaveAcesso;
            Email = email;
            Cpf = cpf;
            TipoUsuario = tipoUsuario;
        }

        public string Login { get; set; }
        public Guid ChaveAcesso { get; set; }
        public string Email { get; set; }
        public Documento Cpf { get; set; }
        public int TipoUsuario { get; set; }

    }
}