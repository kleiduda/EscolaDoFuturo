using Domain.Entity;
using Flunt.Notifications;

namespace Domain.Arguments.Requests
{
    public class CadastroAlunoRequest : Notifiable
    {
        public CadastroAlunoRequest(Aluno aluno, Endereco endereco)
        {
            Aluno = aluno;
            Endereco = endereco;
        }

        public Aluno Aluno { get; set; }
        public Endereco Endereco { get; set; }

    }
}