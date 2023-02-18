using Domain.Entity;
using Flunt.Notifications;

namespace Domain.Arguments.Requests
{
    public class CadastroAlunoRequest : Notifiable
    {
        public CadastroAlunoRequest(string nome, string sobreNome, string documento,
                                    DateTime dataNascimento, int turma, int periodo, Endereco endereco)
        {
            Nome = nome;
            SobreNome = sobreNome;
            Documento = documento;
            DataNascimento = dataNascimento;
            Turma = turma;
            Periodo = periodo;
            Endereco = endereco;
        }

        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Documento { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Turma { get; set; }
        public int Periodo { get; set; }
        public Endereco Endereco { get; set; }

    }
}