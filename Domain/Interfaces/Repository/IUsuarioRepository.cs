using Domain.Arguments.Requests;
using Domain.Commands;
using Domain.Commands.EscolaCommands;

namespace Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<bool> CadastrarUsuario(UsuarioCommand command);
        Task<int> ValidarRegistroNaBase(string cpf);
    }
}