using Domain.Arguments.Requests;
using Domain.Entity;

namespace Domain.Interfaces.Repository
{
    public interface IResponsavelRepository
    {
        Task<bool> CadastrarNovoResponsavel(CadastroResponsavelRequest request);
        Task<Responsavel> ObterResponsavelPeloCodigo(int codigo);
        Task<int> ValidarRegistroNaBase(string value);
        Task<IEnumerable<Responsavel>> ListarResponsaveis(FilterRequest request);
        Task<bool> ExcluirResponsavel(int codigo);
    }
}