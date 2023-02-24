using Dapper;
using Domain.Arguments.Requests;
using Domain.Entity;
using Domain.Interfaces.Repository;
using Repository.DapperConfig;
using Repository.DataBase.Sql;

namespace Repository.DataBase
{
    public class ResponsavelRepository : IResponsavelRepository
    {
        private DbSession _session;
        public ResponsavelRepository(DbSession session)
        {
            _session = session;
        }
        public async Task<bool> CadastrarNovoResponsavel(CadastroResponsavelRequest request)
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

            parameters.Add("nome", request.Responsavel.Nome);
            parameters.Add("sobreNome", request.Responsavel.SobreNome);
            parameters.Add("cpf", request.Responsavel.Cpf);
            parameters.Add("rg", request.Responsavel.Rg);
            parameters.Add("data_nascimento", request.Responsavel.DataNascimento);
            parameters.Add("email", request.Responsavel.Email);
            parameters.Add("telefone", request.Responsavel.Telefone);
            parameters.Add("celular", request.Responsavel.Celular);
            parameters.Add("tipo", request.Responsavel.Tipo);


            var transaction = _session.Connection.BeginTransaction();
            try
            {
                var cd_pessoa = await _session.Connection.ExecuteScalarAsync<int>(PessoaSqlString.CadastroPessoa, parameters, transaction);
                parameters.Add("cd_pessoa", cd_pessoa);

                await _session.Connection.ExecuteScalarAsync(EnderecoSqlString.CadastroEndereco, parameters, transaction);

                int result = await _session.Connection.ExecuteAsync(ResponsavelSqlString.CadastroNovoResponsavel, parameters, transaction);

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

        public async Task<IEnumerable<Responsavel>> ListarResponsaveis(FilterRequest request)
        {
            IEnumerable<Responsavel> responsaveis = new List<Responsavel>();

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("numero_pagina", request.NUMERO_PAGINA);
            parameters.Add("itens_por_pagina", request.ITENS_POR_PAGINA);

            responsaveis = await _session.Connection.QueryAsync<Responsavel>(ResponsavelSqlString.ListarResponsaveis, parameters, _session.Transaction);
            return responsaveis;
        }

        public async Task<Responsavel> ObterResponsavelPeloCodigo(int codigo)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("cd_pessoa", codigo);
            var result = await _session.Connection.QueryFirstOrDefaultAsync<Responsavel>(ResponsavelSqlString.ObterResponsavelPeloCodigo, parameters, _session.Transaction);

            return result;
        }
        public async Task<bool> ExcluirResponsavel(int codigo)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("cd_pessoa", codigo);
            int result = await _session.Connection.ExecuteAsync(ResponsavelSqlString.ExcluirResponsavel, parameters, _session.Transaction);
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

            var result = await _session.Connection.ExecuteScalarAsync<int>(ResponsavelSqlString.ValidarRegistroNaBase, parameters, _session.Transaction);
            return result;
        }
    }
}