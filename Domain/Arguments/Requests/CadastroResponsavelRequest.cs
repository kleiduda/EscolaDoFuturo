using Domain.Entity;
using Flunt.Notifications;

namespace Domain.Arguments.Requests
{
    public class CadastroResponsavelRequest : Notifiable
    {
        public CadastroResponsavelRequest(Responsavel responsavel, Endereco endereco)
        {
            Responsavel = responsavel;
            Endereco = endereco;
        }

        public Responsavel Responsavel { get; set; }
        public Endereco Endereco { get; set; }

    }
}