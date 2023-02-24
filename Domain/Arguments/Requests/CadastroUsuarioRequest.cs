using Domain.Enums;

namespace Domain.Arguments.Requests
{
    public class CadastroUsuarioRequest
    {
        public string Usuario { get; set; }  
        public string Email { get; set; }
        public string Cpf { get; set; }
        public int TipoUsuario { get; set; } 
    }
}