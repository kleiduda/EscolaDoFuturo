using Domain.Arguments.Requests;
using Domain.Commands.EscolaCommands;

namespace Domain.Interfaces.Repository
{
    public interface IEscolaRepository
    {
        Task<bool> CadastrarEscola(EscolaCommand command);
        Task<int> ValidarRegistroNaBase(string cnpj);
    }
}