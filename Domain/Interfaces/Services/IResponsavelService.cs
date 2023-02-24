using Domain.Arguments.Requests;
using Domain.Arguments.Responses;

namespace Domain.Interfaces.Services
{
    public interface IResponsavelService
    {
        Task<ServiceResult> CadastroResponsavel(CadastroRequest request);
        Task<ServiceResult> ObterResponsavelPeloCodigo(int codigo);
        Task<ServiceResult> ListarResponsaveis(FilterRequest request);
        Task<ServiceResult> ExcluirResponsavel(int codigo);
    }
}