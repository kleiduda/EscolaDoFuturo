using Domain.Arguments.Requests;
using Domain.Arguments.Responses;

namespace Domain.Interfaces.Services
{
    public interface IResponsavelService
    {
        Task<ServiceResult> CadastroResponsavel(CadastroResponsavelRequest request);
        Task<ServiceResult> ObterResponsavelPeloCodigo(int codigoAluno);
        Task<ServiceResult> ListarResponsaveis(FilterRequest request);
        Task<ServiceResult> ExcluirResponsavel(int codigoALuno);
    }
}