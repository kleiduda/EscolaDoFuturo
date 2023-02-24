namespace Repository.DataBase.Sql
{
	public static class PessoaSqlString
	{
		public const string CadastroPessoa = @"INSERT INTO TB_PESSOA 
											    (nome, sobrenome, cpf, rg, tipo, email, telefone, celular, data_nascimento) 
											   VALUES 
											    (@nome, @sobrenome, @cpf, @rg, @tipo, @email, @telefone, @celular, @data_nascimento);
												SELECT CAST(SCOPE_IDENTITY() as int)";

		
	}
}

