using Domain.Entity;
using Flunt.Notifications;
using Flunt.Validations;
using Shared.Commands;

namespace Domain.Commands.EscolaCommands
{
    public class EscolaCommand : Notifiable, ICommand
    {
        public EscolaCommand(){}
        public EscolaCommand(Escola escola)
        {
            Escola = escola;
        }
        public Escola Escola { get; set; }

        bool ICommand.Valid()
        {
            AddNotifications(new Contract()
            .IsEmail(this.Escola.Email, "Email", "Email inválido!")
            .IsNotNullOrEmpty(this.Escola.Cnpj, "CNPJ", "Campo Obrigatório!"));

            return Valid;
        }
    }
}