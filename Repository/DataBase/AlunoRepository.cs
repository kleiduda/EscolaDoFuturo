using Dapper;
using Domain.Arguments.Requests;
using Domain.Entity;
using Domain.Interfaces.Repository;
using Repository.DapperConfig;
using Repository.DataBase.Sql;

namespace Repository.DataBase
{
    public class AlunoRepository: IAlunoRepository
    {
        private DbSession _session;
        public AlunoRepository(DbSession session)
        {
            _session = session;
        }
        public async Task<bool> CadastrarNovoAluno(CadastroAlunoRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("pais", request.Endereco.Pais);
            parameters.Add("uf", request.Endereco.Uf);
            parameters.Add("cidade", request.Endereco.Cidade);
            parameters.Add("cep", request.Endereco.Cep);
            parameters.Add("bairro", request.Endereco.Bairro);
            parameters.Add("rua", request.Endereco.Rua);
            parameters.Add("numero", request.Endereco.Numero);
            parameters.Add("complemento", request.Endereco.Complemento);

            parameters.Add("nome", request.Nome);
            parameters.Add("sobreNome", request.SobreNome);
            parameters.Add("documento", request.Documento);
            parameters.Add("dataNascimento", request.DataNascimento);
            parameters.Add("turma", request.Turma);
            parameters.Add("periodo", request.Periodo);

            
            var transaction = _session.Connection.BeginTransaction();
            try
            {
                var cd_endereco = await _session.Connection.ExecuteScalarAsync<int>(EnderecoSqlString.CadastroEndereco, parameters, transaction);
                parameters.Add("cd_endereco", cd_endereco);
                int result = await _session.Connection.ExecuteAsync(AlunoSqlString.CadastroNovoALuno, parameters, transaction);

                transaction.Commit();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<IEnumerable<Aluno>> ListarAlunos(FilterRequest request)
        {
            IEnumerable<Aluno> alunos = new List<Aluno>();

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("numero_pagina", request.NUMERO_PAGINA);
            parameters.Add("itens_por_pagina", request.ITENS_POR_PAGINA);

            alunos = await _session.Connection.QueryAsync<Aluno>(AlunoSqlString.ListarAlunos, parameters, _session.Transaction);
            return alunos;
        }

        public async Task<Aluno> ObterAlunoPeloCodigo(int codigoAluno)
        {
            Aluno aluno = new Aluno();

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("cd_aluno", codigoAluno);
            var result = await _session.Connection.QueryFirstOrDefaultAsync<Aluno>(AlunoSqlString.ObterAlunoPeloCodigo, parameters, _session.Transaction);

            aluno = result;

            return aluno;
        }

        public async Task<bool> ExcluirAluno(int codigoALuno)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("cd_aluno", codigoALuno);
            int result = await _session.Connection.ExecuteAsync(AlunoSqlString.ExcluirAluno, parameters, _session.Transaction);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<int> ValidarRegistroNaBase(string value)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("documento", value);

            var result = await _session.Connection.ExecuteScalarAsync<int>(AlunoSqlString.ValidarRegistroNaBase, parameters, _session.Transaction);
            return result;
        }
    }
}