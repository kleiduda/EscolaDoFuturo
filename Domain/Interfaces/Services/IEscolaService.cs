using Domain.Arguments.Requests;
using Domain.Arguments.Responses;

namespace Domain.Interfaces.Services
{
    public interface IEscolaService
    {
        Task<ServiceResult> CadastroEscola(CadastroEscolaRequest request);
    }
}