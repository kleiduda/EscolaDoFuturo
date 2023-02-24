namespace Repository.DataBase.Sql
{
    public static class EnderecoSqlString
    {
        public const string CadastroEndereco = @"INSERT INTO TB_ENDERECO
												 (pais, uf, cidade, cep, bairro, rua, numero, complemento, cd_pessoa) 
												 VALUES (@pais, @uf, @cidade, @cep, @bairro, @rua, @numero, @complemento, @cd_pessoa)";

        
    }
}

