using Domain.Arguments.Requests;
using Domain.Arguments.Responses;

namespace Domain.Interfaces.Services
{
    public interface IAlunoService
    {
        Task<ServiceResult> CadastroAluno(CadastroRequest request);
        Task<ServiceResult> ObterAlunoPeloCodigo(int codigoAluno);
        Task<ServiceResult> ListarAlunos(FilterRequest request);
        Task<ServiceResult> ExcluirAluno(int codigoALuno);
    }
}