using Dapper;
using Domain.Arguments.Requests;
using Domain.Commands;
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
        public async Task<bool> CadastrarNovoAluno(AlunoCommand request)
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

            parameters.Add("nome", request.Aluno.Nome);
            parameters.Add("sobreNome", request.Aluno.SobreNome);
            parameters.Add("email", request.Aluno.Email);
            parameters.Add("cpf", request.Aluno.Cpf);
            parameters.Add("rg", request.Aluno.Rg);
            parameters.Add("telefone", request.Aluno.Telefone);
            parameters.Add("celular", request.Aluno.Celular);
            parameters.Add("data_nascimento", request.Aluno.DataNascimento);
            parameters.Add("turma", request.Aluno.Turma);
            parameters.Add("periodo", request.Aluno.Periodo);
            parameters.Add("tipo", request.Aluno.Tipo);

            
            var transaction = _session.Connection.BeginTransaction();
            try
            {
                var cd_pessoa = await _session.Connection.ExecuteScalarAsync<int>(PessoaSqlString.CadastroPessoa, parameters, transaction);
                parameters.Add("cd_pessoa", cd_pessoa);

                await _session.Connection.ExecuteScalarAsync(EnderecoSqlString.CadastroEndereco, parameters, transaction);

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
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("cd_pessoa", codigoAluno);
            var result = await _session.Connection.QueryFirstOrDefaultAsync<Aluno>(AlunoSqlString.ObterAlunoPeloCodigo, parameters, _session.Transaction);

            return result;
        }

        public async Task<bool> ExcluirAluno(int codigoALuno)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("cd_pessoa", codigoALuno);
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
            parameters.Add("cpf", value);

            var result = await _session.Connection.ExecuteScalarAsync<int>(AlunoSqlString.ValidarRegistroNaBase, parameters, _session.Transaction);
            return result;
        }
    }
}