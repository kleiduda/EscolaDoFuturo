using Domain.Arguments.Requests;
using Domain.Entity;

namespace Domain.Interfaces.Repository
{
    public interface IAlunoRepository
    {
        Task<bool> CadastrarNovoAluno(CadastroAlunoRequest request);
        Task<Aluno> ObterAlunoPeloCodigo(int codigoAluno);
        Task<int> ValidarRegistroNaBase(string value);
        Task<IEnumerable<Aluno>> ListarAlunos(FilterRequest request);
        Task<bool> ExcluirAluno(int codigoALuno);
    }
}