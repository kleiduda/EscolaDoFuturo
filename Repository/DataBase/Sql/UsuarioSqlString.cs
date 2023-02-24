namespace Repository.DataBase.Sql
{
	public static class UsuarioSqlString
	{
		public const string CadastroUsuario = @"INSERT INTO TB_USUARIO 
												(usuario, chave_acesso, email, cpf, tipo) 
												VALUES (@usuario, @chave_acesso, @email, @cpf, @tipo)";

		public const string ValidarRegistroNaBase = @"SELECT 1 FROM TB_USUARIO WHERE cpf = @cpf";
	}
}

