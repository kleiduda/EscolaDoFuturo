using Domain.Arguments.Requests;
using Domain.Arguments.Responses;

namespace Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<ServiceResult> CadastroUsuario(CadastroUsuarioRequest request);
    }
}