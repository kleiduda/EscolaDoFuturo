using Domain.Entity;
using Flunt.Notifications;
using Flunt.Validations;
using Shared.Commands;

namespace Domain.Commands
{
    public class AlunoCommand : Notifiable, ICommand
    {
        public AlunoCommand(Aluno aluno, Endereco endereco)
        {
            Aluno = aluno;
            Endereco = endereco;
        }
        public Aluno Aluno { get; set; }
        public Endereco Endereco { get; set; }

        bool ICommand.Valid()
        {
            AddNotifications(new Contract()
                            .IsNotNullOrEmpty(this.Aluno.Turma.ToString(), "Turma", "Campo não pode estar vazio")
                            .IsNotNullOrEmpty(this.Aluno.Periodo.ToString(), "Periodo", "Campo não pode estar vazio"));
            return Valid;
        }
    }
}