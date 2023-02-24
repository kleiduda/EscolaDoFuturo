using Domain.Entity;
using Flunt.Notifications;
using Flunt.Validations;
using Shared.Commands;

namespace Domain.Commands
{
    public class UsuarioCommand : Notifiable, ICommand
    {
        public Usuario Usuario { get; set; }
        public UsuarioCommand(Usuario usuario)
        {
            Usuario = usuario;
        }

        public bool Valid()
        {
            AddNotifications(new Contract()
                             .IsEmail(Usuario.Email, "Email", "Email inválido!"));

            return Invalid;
        }
    }
}