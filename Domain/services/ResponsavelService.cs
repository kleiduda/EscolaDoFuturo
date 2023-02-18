using Domain.Arguments.Requests;
using Domain.Arguments.Responses;
using Domain.Interfaces.Services;

namespace Domain.services
{
    public class ResponsavelService : IResponsavelService
    {
        public Task<ServiceResult> CadastroResponsavel(CadastroAlunoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> ExcluirResponsavel(int codigoALuno)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> ListarResponsaveis(FilterRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> ObterResponsavelPeloCodigo(int codigoAluno)
        {
            throw new NotImplementedException();
        }
    }
}