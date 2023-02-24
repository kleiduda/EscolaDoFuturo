namespace Repository.DataBase.Sql
{
	public static class ResponsavelSqlString
	{
		public const string CadastroNovoResponsavel = @"INSERT INTO TB_RESPONSAVEIS 
															(cd_pessoa) 
												  		VALUES 
												  			(@cd_pessoa)";

		public const string ObterResponsavelPeloCodigo = @"SELECT
																pessoa.cd_pessoa as CdResponsavel
																,pessoa.nome
																,pessoa.sobrenome
																,pessoa.cpf
																,pessoa.rg
																,pessoa.telefone
																,pessoa.celular
																FROM TB_PESSOA pessoa
																INNER JOIN TB_RESPONSAVEIS responsavel ON pessoa.cd_pessoa = responsavel.cd_pessoa
												     	   WHERE
												         		pessoa.cd_pessoa = @CD_PESSOA";

		public const string ListarResponsaveis = @"SELECT
													pessoa.cd_pessoa as CdResponsavel
													,pessoa.nome
													,pessoa.sobrenome
													,pessoa.cpf
													,pessoa.rg
													,pessoa.telefone
													,pessoa.celular
													FROM TB_PESSOA pessoa
													INNER JOIN TB_RESPONSAVEIS responsavel ON pessoa.cd_pessoa = responsavel.cd_pessoa
													ORDER BY responsavel.cd_responsavel
											 	OFFSET (@NUMERO_PAGINA -1) * @ITENS_POR_PAGINA ROWS
											 	FETCH NEXT @ITENS_POR_PAGINA ROWS ONLY";
	
		public const string ExcluirResponsavel = @"DELETE FROM TB_PESSOA WHERE CD_PESSOA = @CD_PESSOA";
		public const string ValidarRegistroNaBase = @"SELECT 1 FROM TB_PESSOA WHERE cpf = @cpf";
	}
}

