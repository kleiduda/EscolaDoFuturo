namespace Repository.DataBase.Sql
{
	public static class EscolaSqlString
	{
		public const string Cadastro = @"INSERT INTO TB_ESCOLA
    										(cnpj, razao_social, nome_fantasia, pais, estado, cidade, cep, bairro, numero, complemento, telefone, telefone2, email)
    									VALUES
    										(@cnpj, @razaoSocial, @nomeFantasia, @pais, @estado, @cidade, @cep, @bairro, @numero, @complemento, @telefone, @telefone2, @email)";

		public const string ValidarRegistroNaBase = @"SELECT 1 FROM TB_ESCOLA WHERE cnpj = @cnpj";
	}
}

