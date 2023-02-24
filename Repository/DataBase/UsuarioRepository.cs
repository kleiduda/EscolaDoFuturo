using Dapper;
using Domain.Arguments.Requests;
using Domain.Commands;
using Domain.Commands.EscolaCommands;
using Domain.Interfaces.Repository;
using Repository.DapperConfig;
using Repository.DataBase.Sql;

namespace Repository.DataBase
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private DbSession _session;
        public UsuarioRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<bool> CadastrarUsuario(UsuarioCommand command)
        {
            DynamicParameters parameters = new DynamicParameters();
           
            parameters.Add("usuario", command.Usuario.Login);
            parameters.Add("chave_acesso", command.Usuario.ChaveAcesso);
            parameters.Add("email", command.Usuario.Email);
            parameters.Add("cpf", command.Usuario.Cpf.ToString());
            parameters.Add("tipo", command.Usuario.TipoUsuario);
            
            var transaction = _session.Connection.BeginTransaction();
            try
            {
                int result = await _session.Connection.ExecuteAsync(UsuarioSqlString.CadastroUsuario, parameters, transaction);

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

        public async Task<int> ValidarRegistroNaBase(string cpf)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("cpf", cpf);

            var result = await _session.Connection.ExecuteScalarAsync<int>(UsuarioSqlString.ValidarRegistroNaBase, parameters, _session.Transaction);
            return result;
        }
    }
}