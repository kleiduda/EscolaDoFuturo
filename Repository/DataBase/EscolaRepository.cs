using Dapper;
using Domain.Arguments.Requests;
using Domain.Commands.EscolaCommands;
using Domain.Interfaces.Repository;
using Repository.DapperConfig;
using Repository.DataBase.Sql;

namespace Repository.DataBase
{
    public class EscolaRepository : IEscolaRepository
    {
        private DbSession _session;
        public EscolaRepository(DbSession session)
        {
            _session = session;
        }
        public async Task<bool> CadastrarEscola(EscolaCommand command)
        {
            DynamicParameters parameters = new DynamicParameters();
           
            parameters.Add("cnpj", command.Escola.Cnpj);
            parameters.Add("razaoSocial", command.Escola.RazaoSocial);
            parameters.Add("nomeFantasia", command.Escola.NomeFantasia);
            parameters.Add("pais", command.Escola.Pais);
            parameters.Add("estado", command.Escola.Estado);
            parameters.Add("cidade", command.Escola.Cidade);
            parameters.Add("cep", command.Escola.Cep);
            parameters.Add("bairro", command.Escola.Bairro);
            parameters.Add("rua", command.Escola.Rua);
            parameters.Add("numero", command.Escola.Numero);
            parameters.Add("complemento", command.Escola.Complemento);
            parameters.Add("telefone", command.Escola.Telefone);
            parameters.Add("telefone2", command.Escola.Telefone2);
            parameters.Add("email", command.Escola.Email);
            
            var transaction = _session.Connection.BeginTransaction();
            try
            {
                int result = await _session.Connection.ExecuteAsync(EscolaSqlString.Cadastro, parameters, transaction);

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

        public async Task<int> ValidarRegistroNaBase(string cnpj)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("cnpj", cnpj);

            var result = await _session.Connection.ExecuteScalarAsync<int>(EscolaSqlString.ValidarRegistroNaBase, parameters, _session.Transaction);
            return result;
        }
    }
}