using Domain.Entity;
using Flunt.Notifications;

namespace Domain.Arguments.Requests
{
    public class CadastroResponsavelRequest : Notifiable
    {
        public CadastroResponsavelRequest(string nome, string sobreNome, string cpf, string rg,
                                    DateTime dataNascimento, Endereco endereco)
        {
            Nome = nome;
            SobreNome = sobreNome;
            Cpf = cpf;
            Rg = rg;
            DataNascimento = dataNascimento;
            Endereco = endereco;
        }

        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco Endereco { get; set; }
    }
}